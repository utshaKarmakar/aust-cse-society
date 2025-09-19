using AustCseApp.Data;
using AustCseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AustCseApp.Controllers
{
    // every route here starts with /StudyMaterials
    [Route("StudyMaterials")]
    public class StudyMaterialsController : Controller
    {
        // GET /StudyMaterials
        [HttpGet("")]
        public IActionResult Index() => View(new StudentLookup());

        // GET /StudyMaterials/Courses?year=3&semester=2  (AJAX)
        [HttpGet("Courses")]
        public IActionResult Courses(int year, int semester)
        {
            var courses = HardcodedStudyData.GetCourses(year, semester)
                .Select(c => new {
                    c.Id,
                    c.Code,
                    c.Title,
                    materials = c.Materials.Select(m => new { m.Id, m.Kind })
                });
            return Json(courses);
        }

        // GET /StudyMaterials/Go/123  -> redirects to Drive
        [HttpGet("Go/{courseId:int}")]
        public IActionResult Go(int courseId)
        {
            var url = HardcodedStudyData.GetFirstUrlForCourse(courseId);
            if (string.IsNullOrWhiteSpace(url)) return NotFound("No link for this course.");
            return Redirect(url);
        }

        // optional: /StudyMaterials/GoMaterial?materialId=5
        [HttpGet("GoMaterial")]
        public IActionResult GoMaterial(int materialId)
        {
            var url = HardcodedStudyData.GetUrlForMaterial(materialId);
            if (string.IsNullOrWhiteSpace(url)) return NotFound("Link not found.");
            return Redirect(url);
        }
    }
}
