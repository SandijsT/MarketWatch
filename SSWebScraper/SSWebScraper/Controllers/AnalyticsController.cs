using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using SSWebScraper.DB;
using SSWebScraper.Models;
using SSWebScraper.ScraperService;
using System.Globalization;

namespace SSWebScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        readonly CultureInfo culture = new("en-US");
        private readonly resourceContext _resourceContext;
        private readonly IConfiguration _configuration;
        public AnalyticsController(resourceContext context, IConfiguration configuration)
        {
            _resourceContext = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreatePosts")]
        public async Task<ActionResult> CreatePosts([FromBody] CallerRequest callerRequest)
        {
            try
            {
                var url = "https://www.ss.lv/lv/transport/" + callerRequest.Category + "/" + callerRequest.Make;
                var response = CallUrl(url).Result;

                if (response == null)
                {
                    return BadRequest("Request failure, page not found!");
                }

                var postLinks = ParseLinks(response);
                List<string> nonSavedPosts = new List<string>();

                foreach (var postLink in postLinks)
                {
                    if (!_resourceContext.Vehicles.Any(x => x.Link == postLink))
                    {
                        nonSavedPosts.Add(postLink);
                    }
                }

                var urlAddress = string.Empty;
                List<Vehicle> postObjects = new();
                _ = int.TryParse(_configuration["ParallelTasksCount"], out int parallelTasksCount);

                _ = Parallel.ForEach(nonSavedPosts, new ParallelOptions { MaxDegreeOfParallelism = parallelTasksCount }, post =>
                  {
                      urlAddress = post;

                      response = CallUrl(urlAddress).Result;

                      var postHTML = GetHTML(response);
                      var processedPost = ParsePost(postHTML, post);

                      var vehicleObject = PostMap.MapPost(processedPost, callerRequest);

                      postObjects.Add(vehicleObject);
                  });

                _resourceContext.Vehicles.RemoveRange(_resourceContext.Vehicles.Where(x => x.ModelId == null /*callerRequest.Make*/));

                foreach (Vehicle postObject in postObjects)
                {
                    await _resourceContext.Vehicles.AddAsync(postObject);
                }

                await _resourceContext.SaveChangesAsync();

                var callerResponse = new CallerResponse
                {
                    Category = callerRequest.Category,
                    Make = callerRequest.Make,
                    PostsSaved = postObjects.Count
                };

                return Ok(callerResponse);
            }
            catch (Exception ex)
            {
                return PostProcessingError("Error occured processing posts", ex);
            }
        }

        private ActionResult PostProcessingError(string message, Exception ex)
        {
            throw new AggregateException(message, ex);
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(fullUrl);
            return response;
        }

        private List<string> ParseLinks(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var posts = htmlDoc.DocumentNode.SelectNodes("//a[(contains(@id, 'im'))]");

            if(posts == null)
            {
                throw new ArgumentNullException("No post links found!");
            }

            List<string> postLinks = new List<string>();

            foreach (var link in posts)
            {
                if (link.FirstChild.Attributes.Count > 0)
                {
                    postLinks.Add("https://www.ss.lv/" + link.GetAttributeValue("href", string.Empty));
                }
            }

            return postLinks;
        }

        private string GetHTML(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var post = htmlDoc.DocumentNode.SelectSingleNode("//div[(contains(@id, 'msg_div_msg'))]").InnerHtml;


            if (post == null)
            {
                throw new ArgumentNullException("Could not get post HTML!");
            }

            return post;
        }

        private PostObjectMappings ParsePost(string html, string link)
        {
            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                var priceDOM = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'ads_price']");
                string price;
                if (priceDOM != null)
                {
                    price = priceDOM.InnerText;
                }
                else
                {
                    price = "ELSE";
                }    

                var objectNames = htmlDoc.DocumentNode.SelectNodes("//td[@class ='ads_opt_name']");
                var objectValues = htmlDoc.DocumentNode.SelectNodes("//td[@class = 'ads_opt']");
                //var description = htmlDoc.DocumentNode.ToString;

                var objectList = objectNames.Select((k, i) => new { objectNames[i].InnerText, v = objectValues[i].InnerText })
                        .ToDictionary(x => x.InnerText, x => x.v);

                PostObjectMappings postMatrix = new PostObjectMappings()
                {
                    Price = price,
                    Attributes = objectList,
                    Link = link
                };


                return postMatrix;
            }
            catch (Exception ex)
            {
                return ParsingError("Problem parsing posts.", ex);
            }
        }

        private PostObjectMappings ParsingError(string message, Exception ex)
        {
            throw new ArgumentException(message, ex);
        }
    }
}
