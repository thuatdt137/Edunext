using Edunext.Models;

namespace Edunext.Service
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> getListOfCourses();
    }
}
