using System;
using System.Collections.Generic;

namespace Edunext.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public int CourseId { get; set; }

    public string SlotName { get; set; } = null!;

    public int SlotOrder { get; set; }

    public virtual ICollection<ClassSlotContent> ClassSlotContents { get; set; } = new List<ClassSlotContent>();

    public virtual Course Course { get; set; } = null!;
}
