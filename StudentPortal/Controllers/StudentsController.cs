using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entites;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationsDbContext dbContext;
        public StudentsController(ApplicationsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribe = viewModel.Subscribe,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Student Saved Successfully";
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student =await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if(student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribe = viewModel.Subscribe;

                await dbContext.SaveChangesAsync();

            }

            TempData["SuccessMessage"] = "Student Updated Successfully";
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewMode)
        {
            var student = await dbContext.Students.FindAsync(viewMode.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Student deleted successfully 🗑️";
            }
            return RedirectToAction("List", "Students");
        }
    }
}
