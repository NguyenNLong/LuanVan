using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SemesterSummariesModel
    {
        public int ID { get; set; }
        public decimal AverageScore { get; set; }
        public int Semester { get; set; }

        public int StudentID { get; set; }

        public virtual StudentsModel Student { get; set; }
    }
}
