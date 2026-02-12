using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entites;

namespace StudentPortal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationsDbContext dbContext;

        public TeacherController(ApplicationsDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTeacherViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var teacher = new Teachers
            {
                TeacherName = viewModel.TeacherName,
                TeacherEmail = viewModel.TeacherEmail,
                TeacherPhone = viewModel.TeacherPhone
            };
            await dbContext.Teachers.AddAsync(teacher);
            await dbContext.SaveChangesAsync();

            TempData["Success message"] = "Teacher Added Succssfully";

            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var teacher = await dbContext.Teachers.ToListAsync();
            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var teacher = await dbContext.Teachers.FindAsync(id);
            return View(teacher);
        }
    }
}
