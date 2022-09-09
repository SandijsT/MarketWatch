using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class FuelTypeLanguage
    {
        public int FuelTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUFuelType FuelType { get; set; } = null!;
    }
}
