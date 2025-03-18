using Edunext.Models;

namespace Edunext.Service
{
    public class CourseService : ICourseService
    {
        private readonly EdunextContext _context;
        public CourseService(EdunextContext context) { _context = context; }
        public List<Course> getListOfCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
