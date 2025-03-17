using Edunext.Models;

namespace Edunext.Service
{
    public class UserService : IUserService
    {
        private readonly EdunextContext _context;
        public UserService(EdunextContext context) { _context = context; }
        public Task<IEnumerable<User>> getListOfTeachers()
        {
            throw new NotImplementedException();
        }
    }
}
