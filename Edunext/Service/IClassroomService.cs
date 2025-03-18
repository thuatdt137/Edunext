using Edunext.Models;

namespace Edunext.Service
{
    public interface IClassroomService
    {
        public string saveClass(int teacherId, int courseId, string name);
        public bool validateClass(string name);
    }
}
