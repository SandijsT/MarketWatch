using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUModel
    {
        public LUModel()
        {
            ModelLanguages = new HashSet<ModelLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int ModelId { get; set; }
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;

        public virtual ICollection<ModelLanguage> ModelLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
