using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class ModelLanguage
    {
        public int ModelId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUModel Model { get; set; } = null!;
    }
}
