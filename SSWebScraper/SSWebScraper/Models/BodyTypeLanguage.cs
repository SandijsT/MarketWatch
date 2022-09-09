using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class BodyTypeLanguage
    {
        public int BodyTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUBodyType BodyType { get; set; } = null!;
    }
}
