using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class PostTypeLanguage
    {
        public int PostTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUPostType PostType { get; set; } = null!;
    }
}
