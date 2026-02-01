using System;
using System.Collections.Generic;

namespace BlazorApp1;

public partial class Category
{
    public int Id { get; set; } = 0;

    public string? Name { get; set; }

    public string? Clause { get; set; }

    public string? Modifier { get; set; }

    public int? Description { get; set; }
}
