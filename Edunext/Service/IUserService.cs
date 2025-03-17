using Edunext.Models;

namespace Edunext.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> getListOfTeachers();
    }
}
