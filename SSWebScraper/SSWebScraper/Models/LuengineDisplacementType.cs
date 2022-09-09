using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUEngineDisplacementType
    {
        public LUEngineDisplacementType()
        {
            EngineDisplacementTypeLanguages = new HashSet<EngineDisplacementTypeLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int EngineDisplacementTypeId { get; set; }
        public string EngineDisplacementType { get; set; } = null!;
        public decimal EngineDisplacement { get; set; }

        public virtual ICollection<EngineDisplacementTypeLanguage> EngineDisplacementTypeLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
