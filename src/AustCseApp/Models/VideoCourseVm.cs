using System.Collections.Generic;

namespace AustCseApp.Models
{
    public class VideoCourseVm
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public string Title { get; set; } = "";
        public List<VideoLinkVm> Links { get; set; } = new();
    }

    public class VideoLinkVm
    {
        public int Id { get; set; }
        public string Label { get; set; } = "YouTube";
        public string Url { get; set; } = "";
    }
}
