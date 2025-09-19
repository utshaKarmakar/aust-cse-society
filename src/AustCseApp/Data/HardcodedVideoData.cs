using System.Collections.Generic;
using System.Linq;
using AustCseApp.Models;

namespace AustCseApp.Data
{
    /// <summary>
    /// Hardcoded course → YouTube video links (NOT using any database).
    /// You only need to fill in the VIDEO LECTURE links for Year 3, Semester 2 below.
    /// </summary>
    public static class HardcodedVideoData
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
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=kXN3pkKeKQk&list=PL1_Y9fgnIyo5OFDa_hQeYGrHnnrPnh1WM")
                }),
                NewCourse("CSE 3201", "Introduction to Computer Networks", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=iyPHirikUPg&list=PL1_Y9fgnIyo75zjnRYlA1Lk28BnfsSm-z")
                }),
                NewCourse("CSE 3202", "Introduction to Computer Networks Lab", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=HKDKrYg-G2Q&list=PL1_Y9fgnIyo6WP4-ZtuAyRxbc4Yn5Bl-t")
                }),
                NewCourse("CSE 3207", "Introduction to Artificial Intelligence", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=Y8QzRSoRSF0&list=PL1_Y9fgnIyo5uuJceC8-ujb6oGyF5zVsf")
                }),
                NewCourse("CSE 3208", "Introduction to Artificial Intelligence Lab", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/@sapphirefang1998/playlists")
                }),
                NewCourse("CSE 3213", "Operating System", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=bzvsmzCgahY&list=PL1_Y9fgnIyo7Pw-_UJcCcjvnEpNSPErhp")
                }),
                NewCourse("CSE 3214", "Operating System Lab", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=BazVBDL_ckg&list=PL1_Y9fgnIyo6NA5SrTPeXyAkwYt1FKg6l")
                }),
                NewCourse("CSE 3223", "Information System Design and Software Engineering", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=kuy3lj2zGfI&list=PL1_Y9fgnIyo6RlUNOwP4PAbp8eaWzoBhc&pp=0gcJCaIEOCosWNin")
                }),
                NewCourse("CSE 3224", "Information System Design and Software Engineering Lab", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=iWJjhaGPdjw&list=PL1_Y9fgnIyo7KSFsPZYQoeIvY5C1yvnGn")
                }),
                NewCourse("HUM 3207", "Industrial Law and Safety Management", new []
                {
                    ("Video Lecture", "https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=n2BbbJ50Iio&list=PL1_Y9fgnIyo5OkvLtw8xmyuSUuv_HHdcy")
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
