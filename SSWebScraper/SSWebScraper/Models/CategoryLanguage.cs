using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class CategoryLanguage
    {
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUCategory Category { get; set; } = null!;
    }
}
