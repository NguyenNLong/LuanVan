using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ConductModel
    {
        public int ID { get; set; }
        public int StudentsID { get; set; }
        public int ClassesID { get; set; }
        public int SemesterID { get; set; }
        public string ConductEvaluation { get; set; } = string.Empty;

        // Navigation properties
        public StudentsModel Student { get; set; } = null!;
        public ClassModel Class { get; set; } = null!;
        public SemestersModel Semester { get; set; } = null!;
    }

}
