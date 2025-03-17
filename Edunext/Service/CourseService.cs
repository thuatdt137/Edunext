using Edunext.Models;

namespace Edunext.Service
{
    public class CourseService : ICourseService
    {
        private readonly EdunextContext _context;
        public CourseService(EdunextContext context) { _context = context; }
        public Task<IEnumerable<Course>> getListOfCourses()
        {
            throw new NotImplementedException();
        }
    }
}
