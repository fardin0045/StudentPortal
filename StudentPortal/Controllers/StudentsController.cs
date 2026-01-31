using Microsoft.AspNetCore.Mvc;
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
        public async  Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribe = viewModel.Subscribe,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
