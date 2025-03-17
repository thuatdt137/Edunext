using Edunext.Models;

namespace Edunext.Service
{
    public class ClassroomService : IClassroomService
    {
        public Task<IEnumerable<Classroom>> saveClass(int teacherId, int courseId, string name)
        {
            throw new NotImplementedException();
        }

        public bool validateClass(string name)
        {
            throw new NotImplementedException();
        }
    }
}
