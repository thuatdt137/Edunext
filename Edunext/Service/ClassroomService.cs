using Edunext.Models;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Service
{
    public class ClassroomService : IClassroomService
    {
        private readonly EdunextContext _context;
        public ClassroomService(EdunextContext context) { _context = context; }
        public string saveClass(int teacherId, int courseId, string name)
        {
            string message = "";
            try
            {
                var boolCheck = validateClass(name);
                
                if (boolCheck)
                {
                    message = "Class name already exists.";
                }
                else
                {
                    var newClass = new Classroom
                    {
                        TeacherId = teacherId,
                        CourseId = courseId,
                        ClassName = name
                    };
                    _context.Classrooms.Add(newClass);
                    _context.SaveChanges();

                    message = "Class created successfully.";

                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return message;
        }

        public bool validateClass(string name)
        {
            var queryClass = _context.Classrooms.FirstOrDefault(x => x.ClassName.Equals(name.Trim()));

            return queryClass != null;
        }

   

    }
}
