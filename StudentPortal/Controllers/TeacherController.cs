using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;

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

    }
}
