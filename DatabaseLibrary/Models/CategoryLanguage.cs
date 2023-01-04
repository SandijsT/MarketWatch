using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class CategoryLanguage
{
    public int CategoryId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual Lucategory Category { get; set; }
}
