using System;
using System.Collections.Generic;

namespace BlazorApp1;

public partial class Answer
{
    public int? Game { get; set; }

    public string? StateName { get; set; }

    public int? AnswerSlot { get; set; }

    public int? NumberOfGuesses { get; set; }

    public int Id { get; set; }

    public virtual Game? GameNavigation { get; set; }
}
