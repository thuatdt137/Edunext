using Edunext.Models;

namespace Edunext.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly EdunextContext _context;
        public UserRepository(EdunextContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<User>> getListOfStudents()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> getListOfTeachers()
        {
            throw new NotImplementedException();
        }
    }
}
