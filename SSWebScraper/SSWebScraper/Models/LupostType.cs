using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUPostType
    {
        public LUPostType()
        {
            PostTypeLanguages = new HashSet<PostTypeLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int PostTypeId { get; set; }
        public string PostType { get; set; } = null!;

        public virtual ICollection<PostTypeLanguage> PostTypeLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
