using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SSWebScraper.Contexts;
using SSWebScraper.Controllers;
using NUnit.Compatibility;
using SSWebScraper.ScraperService;

namespace UnitTests
{
    [TestFixture]
    public class ScraperTests
    {
        private readonly resourceContext _resourceContext;
        private readonly IConfiguration _configuration;

        [Test]
        public void ParseLinks_HTMLLinkTag_AreEqual()
        {
            var primeService = new ScraperController(_resourceContext, _configuration);
            var link = "<a href=\"/msg/lv/transport/cars/bmw/530/ajggl.html\" id=\"im52616554\"><img src=\"https://i.ss.lv/gallery/6/1025/256194/51238698.th2.jpg\" alt=\"\" class=\"isfoto foto_list\"></a>";

            var result = primeService.ParseLinks(link);

            Assert.AreEqual(result[0], "https://www.ss.lv//msg/lv/transport/cars/bmw/530/ajggl.html", "ParseLinks did not return a valid url");
        }

        [Test]
        public void ParsePost_PostHTML_AreEqual()
        {
            var primeService = new ScraperController(_resourceContext, _configuration);
            var link = "<a href=\"/msg/lv/transport/cars/bmw/530/ajggl.html\" id=\"im52616554\"><img src=\"https://i.ss.lv/gallery/6/1025/256194/51238698.th2.jpg\" alt=\"\" class=\"isfoto foto_list\"></a>";
            var html = "Pārdodu transportlīdzekli.<br><br><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\" class=\"options_list\"><tr><td width=\"50%\" valign=\"top\"><table border=\"0\" width=\"100%\" cellpadding=\"1\" cellspacing=\"0\"><tr><td height=\"28\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Marka </td><td class=\"ads_opt\" id=\"tdo_31\" style=\"padding-top:4px;\" nowrap=\"\"><b>Bmw 525</b></td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Izlaiduma gads:</td><td class=\"ads_opt\" id=\"tdo_18\" nowrap=\"\">1999 septembris</td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Motors:</td><td class=\"ads_opt\" id=\"tdo_15\" nowrap=\"\">2.5 dīzelis</td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Ātr.kārba:</td><td class=\"ads_opt\" id=\"tdo_35\" nowrap=\"\">Manuāla 5 ātrumi</td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Nobraukums, km:</td><td class=\"ads_opt\" id=\"tdo_16\" nowrap=\"\">370 000</td></tr></table></td><td width=\"50%\" valign=\"top\"><table border=\"0\" width=\"100%\" cellpadding=\"1\" cellspacing=\"0\"><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Krāsa:</td><td class=\"ads_opt\" id=\"tdo_17\" nowrap=\"\">Sudraba <div class=\"ads_color_opt\" style=\"background-color:#CCCCCC;\"></div></td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Virsbūves tips:</td><td class=\"ads_opt\" id=\"tdo_32\" nowrap=\"\">Universāls</td></tr><tr><td height=\"20\" class=\"ads_opt_name\" width=\"30\" nowrap=\"\">Tehniskā apskate:</td><td class=\"ads_opt\" id=\"tdo_223\" nowrap=\"\">06.2023</td></tr><tr><td class=\"ads_opt\" id=\"tdo_1678\" nowrap=\"\"></td></tr><tr><td class=\"ads_opt\" id=\"tdo_1714\" nowrap=\"\"></td></tr></table></td></tr></table><table style=\"border-top:1px #eee solid;padding-top:5px;margin-top:10px;\" cellpadding=\"1\" cellspacing=\"0\" border=\"0\" width=\"100%\"><tr><td valign=\"top\" height=\"20\" class=\"ads_opt_name_big\" width=\"30\" nowrap=\"\">Cena:</td><td class=\"ads_price\" valign=\"top\" nowrap=\"\"><span style=\"float:left;\"><span class=\"ads_price\" id=\"tdo_8\">1 100 €</span></span></td></tr></table>";
            var postObjectMapping = new PostObjectMappings()
            {
                Attributes = new Dictionary<string, string>()
                {
                    { "Marka ",  "Bmw 525"},
                    { "Izlaiduma gads:",  "1999 septembris"},
                    { "Motors:",  "2.5 dīzelis"},
                    { "Ātr.kārba:",  "Manuāla 5 ātrumi"},
                    { "Nobraukums, km:",  "370 000"},
                    { "Krāsa:",  "Sudraba "},
                    { "Virsbūves tips:",  "Universāls"},
                    { "Tehniskā apskate:",  "06.2023"},
                },
                Link = link,
                PostId = 0,
                Price = "1 100 €"
            };

            var result = primeService.ParsePost(html, link);

            Assert.AreEqual(result.Attributes, postObjectMapping.Attributes, $"ParsePost failed attributes were not equal");
            Assert.AreEqual(result.Link, postObjectMapping.Link, $"ParsePost failed links were not equal");
            Assert.AreEqual(result.PostId, postObjectMapping.PostId, $"ParsePost failed postid's were not equal");
            Assert.AreEqual(result.Price, postObjectMapping.Price, $"ParsePost failed prices were not equal");
        }
    }
    
    
}
