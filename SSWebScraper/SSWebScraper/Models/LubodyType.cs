using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUBodyType
    {
        public LUBodyType()
        {
            BodyTypeLanguages = new HashSet<BodyTypeLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int BodyTypeId { get; set; }
        public string BodyType { get; set; } = null!;

        public virtual ICollection<BodyTypeLanguage> BodyTypeLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
