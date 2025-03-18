using Edunext.Models;

namespace Edunext.Service
{
    public class UserService : IUserService
    {
        private readonly EdunextContext _context;
        public UserService(EdunextContext context) { _context = context; }
        public List<User> getListOfTeachers()
        {
            return _context.Users.Where(x => x.Role == 2).ToList();
        }
    }
}
