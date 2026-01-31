using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
