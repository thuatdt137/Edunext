using System;
using System.Collections.Generic;

namespace Edunext.Models;

public partial class Assignment
{
    public int AssignmentId { get; set; }

    public int ClassSlotId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly DueDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();

    public virtual ClassSlotContent ClassSlot { get; set; } = null!;
}
