using System;
using System.Collections.Generic;

namespace SSWebScraper.Models
{
    public partial class LUTransmissionType
    {
        public LUTransmissionType()
        {
            TransmissionTypeLanguages = new HashSet<TransmissionTypeLanguage>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int TransmissionTypeId { get; set; }
        public string TransmissionType { get; set; } = null!;
        public int? GearCount { get; set; }

        public virtual ICollection<TransmissionTypeLanguage> TransmissionTypeLanguages { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
