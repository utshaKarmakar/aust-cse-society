using System.Collections.Generic;

namespace AustCseApp.Models
{
    public class CourseVm
    {
        public int Id { get; set; }          // unique id in our hardcoded list
        public string Code { get; set; } = "";
        public string Title { get; set; } = "";
        public List<MaterialVm> Materials { get; set; } = new();
    }

    public class MaterialVm
    {
        public int Id { get; set; }          // unique id in our hardcoded list
        public string Kind { get; set; } = "Link"; // Slides/Notes/Book
        public string DriveUrl { get; set; } = "";
    }
}
