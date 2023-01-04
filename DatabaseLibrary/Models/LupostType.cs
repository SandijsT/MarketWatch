using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class LupostType
{
    public int PostTypeId { get; set; }

    public string PostType { get; set; }

    public virtual ICollection<PostTypeLanguage> PostTypeLanguages { get; } = new List<PostTypeLanguage>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
