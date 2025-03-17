using Edunext.Models;

namespace Edunext.Repository
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<Classroom>> saveClass(int teacherId, int courseId, string name);
        Boolean validateClass(string name);
    }
}
