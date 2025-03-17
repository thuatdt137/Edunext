using Edunext.Service;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IUserService userService;
        private readonly IClassroomService classroomService;
        private readonly ICourseService courseService;
        public ClassroomController(IUserService userService, IClassroomService classroomService, ICourseService courseService)
        {
            this.userService = userService;
            this.classroomService = classroomService;
            this.courseService = courseService;
        }
    }
}
