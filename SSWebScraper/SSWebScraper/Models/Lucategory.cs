using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUCategory
    {
        public LUCategory()
        {
            CategoryLanguages = new HashSet<CategoryLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;

        public virtual ICollection<CategoryLanguage> CategoryLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
