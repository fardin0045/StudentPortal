using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entites;

namespace StudentPortal.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationsDbContext dbContext;
        public CourseController(ApplicationsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost ]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            if (!ModelState.IsValid) { 
                return View(viewModel);
            }
            var course = new Courses
            {
                CourseName = viewModel.CourseName,
                CourseCode = viewModel.CourseCode,
                Credit = viewModel.Credit
            };

            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Course Added Successfully";
            return RedirectToAction("Add");
        }
        public async Task<IActionResult> List()
        {
            var course = await dbContext.Courses.ToListAsync();
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var course = await dbContext.Courses.FindAsync(id);
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (Courses viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var course = await dbContext.Courses.FindAsync(viewModel.Id);
            if(course != null)
            {
                course.CourseName = viewModel.CourseName;
                course.CourseCode = viewModel.CourseCode;
                course.Credit = viewModel.Credit;

                await dbContext.SaveChangesAsync ();
            }
            TempData["SuccessMessage"] = "Course Update Successfully";
            return RedirectToAction("List", "Course");
        }
    }
}
