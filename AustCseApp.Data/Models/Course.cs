using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustCseApp.Data.Models
{
    public class Course
    {
        public string Code { get; set; } = "";
        public string Title { get; set; } = "";
        public double Credit { get; set; }
    }
}
