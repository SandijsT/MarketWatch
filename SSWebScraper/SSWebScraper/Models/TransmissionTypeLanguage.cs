using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class TransmissionTypeLanguage
    {
        public int TransmissionTypeId { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual LUTransmissionType TransmissionType { get; set; } = null!;
    }
}
