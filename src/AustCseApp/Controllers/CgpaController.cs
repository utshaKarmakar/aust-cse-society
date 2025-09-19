using AustCseApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace AustCseApp.Controllers
{
    public class CgpaController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        // Returns fixed course list for Year + Semester
        [HttpGet]
        public IActionResult Courses(int year, int semester)
        {
            var key = Curriculum.Key(year, semester);
            if (!Curriculum.Courses.TryGetValue(key, out var list))
                return NotFound(new { message = $"No curriculum found for Y{year} S{semester}" });

            return Json(list.Select(c => new { c.Code, c.Title, c.Credit }));
        }
    }
}
