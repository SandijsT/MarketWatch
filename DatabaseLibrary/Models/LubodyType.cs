using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class LubodyType
{
    public int BodyTypeId { get; set; }

    public string BodyType { get; set; }

    public virtual ICollection<BodyTypeLanguage> BodyTypeLanguages { get; } = new List<BodyTypeLanguage>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
