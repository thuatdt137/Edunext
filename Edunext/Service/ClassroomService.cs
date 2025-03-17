using Edunext.Models;

namespace Edunext.Service
{
    public class ClassroomService : IClassroomService
    {
        private readonly EdunextContext _context;
        public ClassroomService(EdunextContext context) { _context = context; }
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
