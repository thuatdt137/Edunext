using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edunext.Models;
using Edunext.Service;

namespace Edunext.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly EdunextContext _context;
        private readonly IClassroomService _classroomService;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;

        public ClassroomsController(EdunextContext context,IClassroomService classroomService, IUserService userService,ICourseService courseService)
        {
            _context = context;
            _classroomService = classroomService;
            _userService = userService;
            _courseService = courseService;
        }

        // GET: Classrooms
        public async Task<IActionResult> Index()
        {
            var edunextContext = _context.Classrooms.Include(c => c.Course).Include(c => c.Teacher);
            return View(await edunextContext.ToListAsync());
        }

        // GET: Classrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classrooms/Create
        public IActionResult Create()
        {
            var listofTeacher = _userService.getListOfTeachers();
            var listofCourse = _courseService.getListOfCourses();
            ViewData["CourseId"] = new SelectList(listofCourse, "CourseId", "CourseName");
            ViewData["TeacherId"] = new SelectList(listofTeacher, "UserId", "LastName");
            return View();
        }

        // POST: Classrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,CourseId,SemesterId,TeacherId,ClassName")] Classroom classroom)
        {
            var boolCheck = _classroomService.validateClass(classroom.ClassName);
            var msg = "";
            if (boolCheck)
            {
                msg = "Class name already exists.";
            }
            else
            {
                msg = _classroomService.saveClass(classroom.TeacherId, classroom.CourseId, classroom.ClassName);
            }
            TempData["Message"] = msg;
            return RedirectToAction("Create");
        }

        // GET: Classrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classroom.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Users, "UserId", "UserId", classroom.TeacherId);
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,CourseId,SemesterId,TeacherId,ClassName")] Classroom classroom)
        {
            if (id != classroom.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassroomExists(classroom.ClassId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classroom.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Users, "UserId", "UserId", classroom.TeacherId);
            return View(classroom);
        }

        // GET: Classrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom != null)
            {
                _context.Classrooms.Remove(classroom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassroomExists(int id)
        {
            return _context.Classrooms.Any(e => e.ClassId == id);
        }
    }
}
