using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Lumodel
{
    public int ModelId { get; set; }

    public string Model { get; set; }

    public string Manufacturer { get; set; }

    public virtual ICollection<ModelLanguage> ModelLanguages { get; } = new List<ModelLanguage>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
