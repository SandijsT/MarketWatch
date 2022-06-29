namespace SSWebScraper.Models
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string PostHTML { get; set; }
        public DateTime PostSavedDate { get; set; }
    }
}
