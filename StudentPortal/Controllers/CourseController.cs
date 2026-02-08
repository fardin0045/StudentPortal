using Microsoft.AspNetCore.Mvc;
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

    }
}
