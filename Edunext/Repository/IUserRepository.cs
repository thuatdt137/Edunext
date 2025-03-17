using Edunext.Models;

namespace Edunext.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> getListOfTeachers();
        Task<IEnumerable<User>> getListOfStudents();

    }
}
