using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class StudentClassesModel
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public int SchoolYearID { get; set; } // Khóa ngoại
        public SchoolYearModel SchoolYear { get; set; } // Navigation property
    }
}
