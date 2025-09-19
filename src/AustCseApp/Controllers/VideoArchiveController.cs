using System.Linq;                 // <<< needed for Select(...)
using AustCseApp.Data;
using AustCseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AustCseApp.Controllers
{
    [Route("VideoArchive")]
    public class VideoArchiveController : Controller
    {
        // GET /VideoArchive
        [HttpGet("")]
        public IActionResult Index() => View(new StudentLookup());

        // GET /VideoArchive/Courses?year=3&semester=2
        [HttpGet("Courses")]
        public IActionResult Courses(int year, int semester)
        {
            var courses = HardcodedVideoData.GetCourses(year, semester)
                .Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Title,
                    // your HardcodedVideoData currently stores items in Materials with Kind/DriveUrl
                    links = c.Materials.Select(m => new { Id = m.Id, Label = m.Kind })
                });

            return Json(courses);
        }

        // GET /VideoArchive/Watch/123 → redirect to first video (stored as first "material")
        [HttpGet("Watch/{courseId:int}")]
        public IActionResult Watch(int courseId)
        {
            var url = HardcodedVideoData.GetFirstUrlForCourse(courseId);
            if (string.IsNullOrWhiteSpace(url)) return NotFound("No video link found.");
            return Redirect(url);
        }

        // GET /VideoArchive/WatchLink?linkId=5 → redirect to a specific video
        [HttpGet("WatchLink")]
        public IActionResult WatchLink(int linkId)
        {
            var url = HardcodedVideoData.GetUrlForMaterial(linkId);
            if (string.IsNullOrWhiteSpace(url)) return NotFound("Link not found.");
            return Redirect(url);
        }
    }
}
