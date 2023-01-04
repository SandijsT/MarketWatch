using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class PostTypeLanguage
{
    public int PostTypeId { get; set; }

    public int LanguageId { get; set; }

    public string Description { get; set; }

    public virtual LupostType PostType { get; set; }
}
