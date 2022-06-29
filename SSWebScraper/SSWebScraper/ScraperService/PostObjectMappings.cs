namespace SSWebScraper.ScraperService
{
    public class PostObjectMappings
    {
        public int PostId { get; set; }
        public string? Price { get; set; }
        public Dictionary<string, string>? Attributes { get; set; }
        public string? Desription { get; set; }
        public string? Link { get; set; }
    }
}
