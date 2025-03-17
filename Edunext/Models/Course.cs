using System;
using System.Collections.Generic;

namespace Edunext.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseCode { get; set; } = null!;

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
