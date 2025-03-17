using Edunext.Models;

namespace Edunext.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> getListOfCourses();
    }
}
