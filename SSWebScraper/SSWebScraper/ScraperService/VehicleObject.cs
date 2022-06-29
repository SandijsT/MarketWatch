using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSWebScraper.ScraperService
{
    public class VehicleObject
    {
        [Key]
        public int PostId { get; set; }
        public string? Price { get; set; }
        public string? Title { get; set; }
        public string? Desription { get; set; }
        public string? Make { get; set; }
        public string? ReleaseDate { get; set; }
        public string? EngineDisplacement { get; set; }
        public string? Transmission { get; set; }
        public string? Mileage { get; set; }
        public string? Color { get; set; }
        public string? BodyType { get; set; }
        public string? TIEndDate { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public int? Views { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? SavedDate { get; set; }
    }
}
