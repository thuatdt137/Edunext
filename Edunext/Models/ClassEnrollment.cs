using System;
using System.Collections.Generic;

namespace Edunext.Models;

public partial class ClassEnrollment
{
    public int EnrollmentId { get; set; }

    public int ClassId { get; set; }

    public int UserId { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public virtual Classroom Class { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
