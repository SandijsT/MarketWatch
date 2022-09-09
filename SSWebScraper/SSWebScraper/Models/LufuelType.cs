using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUFuelType
    {
        public LUFuelType()
        {
            FuelTypeLanguages = new HashSet<FuelTypeLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int FuelTypeId { get; set; }
        public string FuelType { get; set; } = null!;

        public virtual ICollection<FuelTypeLanguage> FuelTypeLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
