using Edunext.Models;

namespace Edunext.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        public readonly EdunextContext _context;
        public ClassroomRepository(EdunextContext context)
        {
            _context = context;
        }
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
