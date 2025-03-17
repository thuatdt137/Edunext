using Edunext.Models;

namespace Edunext.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public readonly EdunextContext _context;
        public CourseRepository(EdunextContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Course>> getListOfCourses()
        {
            throw new NotImplementedException();
        }
    }
}
