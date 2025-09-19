using System.Collections.Generic;
using System.Linq;
using AustCseApp.Models;

namespace AustCseApp.Data
{
    /// <summary>
    /// Hardcoded course → Drive links (NOT using any database).
    /// You only need to fill in the NOTE links for Year 3, Semester 2 below.
    /// </summary>
    public static class HardcodedStudyData
    {
        private static int _courseId = 1;
        private static int _materialId = 1;

        // (Year, Semester) -> list of courses
        private static readonly Dictionary<(int Year, int Sem), List<CourseVm>> Data = new()
        {
            // =========================
            // YEAR 3 — SEMESTER 2 ONLY
            // =========================
            [(3, 2)] = new List<CourseVm>
            {
                NewCourse("CSE 3200", "Software Development-V", new []
                {
                    // NOTES ONLY — put your Google Drive link:
                    ("Notes", "https://drive.google.com/drive/folders/1qKn7MSzFoCs8JEPfAPB9j1NohbO8HoMx")
                }),
                NewCourse("CSE 3201", "Introduction to Computer Networks", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1BmgMU420NZQj9ITuX0BVLPoAanx_Fk60")
                }),
                NewCourse("CSE 3202", "Introduction to Computer Networks Lab", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1lHP8Nbw3XTVbfrZQblt-GlsdJw4Lryah")
                }),
                NewCourse("CSE 3207", "Introduction to Artificial Intelligence", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1uh4Vxh7J-MVX5LuYaf21E7M9mmqz-8Da")
                }),
                NewCourse("CSE 3208", "Introduction to Artificial Intelligence Lab", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1yjzDcNESIvH9zoWGLmxlkY9MZxBzJZM_")
                }),
                NewCourse("CSE 3213", "Operating System", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1sI0rMg7iNbHduOrhkgsJEaLheWImF9ew")
                }),
                NewCourse("CSE 3214", "Operating System Lab", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1Qn7Ne6r9WrVpD5klvHPkSadr1KI0KY6R")
                }),
                NewCourse("CSE 3223", "Information System Design and Software Engineering", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1bCvvHrzSiRWXYZuWxtN2VTSEwpTKuN4y")
                }),
                NewCourse("CSE 3224", "Information System Design and Software Engineering Lab", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1qKn7MSzFoCs8JEPfAPB9j1NohbO8HoMx")
                }),
                NewCourse("HUM 3207", "Industrial Law and Safety Management", new []
                {
                    ("Notes", "https://drive.google.com/drive/folders/1PbaDCo65opNnkyLY2HFByUfHmiyC2ZDT")
                }),
            }
        };

        // ---------- helpers ----------
        private static CourseVm NewCourse(string code, string title, IEnumerable<(string kind, string url)> materials)
        {
            var c = new CourseVm { Id = _courseId++, Code = code, Title = title };
            foreach (var (kind, url) in materials)
                c.Materials.Add(new MaterialVm { Id = _materialId++, Kind = kind, DriveUrl = url });
            return c;
        }

        public static List<CourseVm> GetCourses(int year, int sem)
            => Data.TryGetValue((year, sem), out var list) ? list : new List<CourseVm>();

        public static string? GetFirstUrlForCourse(int courseId)
            => Data.Values.SelectMany(x => x)
                .FirstOrDefault(c => c.Id == courseId)?
                .Materials.OrderBy(m => m.Id).FirstOrDefault()?.DriveUrl;

        public static string? GetUrlForMaterial(int materialId)
            => Data.Values.SelectMany(x => x).SelectMany(c => c.Materials)
                .FirstOrDefault(m => m.Id == materialId)?.DriveUrl;
    }
}
