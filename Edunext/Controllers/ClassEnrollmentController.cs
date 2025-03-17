using Edunext.Service;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.Controllers
{
    public class ClassEnrollmentController : Controller
    {
        private readonly IClassEnrollmentService _classEnrollmentService;
        private readonly IUserService _userService;
        public ClassEnrollmentController(IClassEnrollmentService classEnrollmentService, IUserService userService)
        {
            _classEnrollmentService = classEnrollmentService;
            _userService = userService;
        }
    }
}
