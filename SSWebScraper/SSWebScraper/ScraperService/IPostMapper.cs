using DatabaseLibrary.Models;

namespace SSWebScraper.ScraperService
{
    public interface IPostMapper
    {
        public Vehicle MapPost(PostObjectMappings postMappings, CallerRequest request);
    }
}
