using System;
using System.Collections.Generic;

namespace Edunext.Models;

public partial class Classroom
{
    public int ClassId { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; } = new List<ClassEnrollment>();

    public virtual ICollection<ClassSlotContent> ClassSlotContents { get; set; } = new List<ClassSlotContent>();

    public virtual Course Course { get; set; } = null!;

    public virtual User Teacher { get; set; } = null!;
}
