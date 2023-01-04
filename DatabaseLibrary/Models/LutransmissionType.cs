using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class LutransmissionType
{
    public int TransmissionTypeId { get; set; }

    public string TransmissionType { get; set; }

    public int? GearCount { get; set; }

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<TransmissionTypeLanguage> TransmissionTypeLanguages { get; } = new List<TransmissionTypeLanguage>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
