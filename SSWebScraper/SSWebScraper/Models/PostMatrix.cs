using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSWebScraper.Models
{
    public class PostMatrix
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Make { get; set; }
        public string? Link { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public string? Views { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ViewsCount { get; set; }
        public DateTime PubDate { get; set; }
    }
}
