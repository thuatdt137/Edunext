using Edunext.Models;

namespace Edunext.Service
{
    public interface IClassroomService
    {
        public Task<IEnumerable<Classroom>> saveClass(int teacherId, int courseId, string name);

        public bool validateClass(string name);
    }
}
