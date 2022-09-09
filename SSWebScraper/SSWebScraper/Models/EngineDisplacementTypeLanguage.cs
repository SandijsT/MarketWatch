using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class EngineDisplacementTypeLanguage
    {
        public int EngineDisplacementTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUEngineDisplacementType EngineDisplacementType { get; set; } = null!;
    }
}
