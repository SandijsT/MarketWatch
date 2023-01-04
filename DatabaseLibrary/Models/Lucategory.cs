using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Lucategory
{
    public int CategoryId { get; set; }

    public string Category { get; set; }

    public virtual ICollection<CategoryLanguage> CategoryLanguages { get; } = new List<CategoryLanguage>();

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
