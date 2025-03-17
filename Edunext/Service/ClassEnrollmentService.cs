using Edunext.Models;

namespace Edunext.Service
{
    public class ClassEnrollmentService : IClassEnrollmentService
    {
        private readonly EdunextContext _context;
        public ClassEnrollmentService(EdunextContext context) {  _context = context; }
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
