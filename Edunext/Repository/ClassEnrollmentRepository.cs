using Edunext.Models;

namespace Edunext.Repository
{
    public class ClassEnrollmentRepository : IClassEnrollmentRepository
    {
        public readonly EdunextContext _context;
        public ClassEnrollmentRepository(EdunextContext context)
        {
            _context = context;
        }
        public string SaveClassEnrollment(int id, int name)
        {
            throw new NotImplementedException();
        }

        public bool validateClassEnrollment(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
