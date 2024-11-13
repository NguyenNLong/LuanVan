using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ScoresModel
    {
        public int ID { get; set; }
        public int Semester { get; set; }
        public decimal OralTest { get; set; }
        public decimal Test15Min { get; set; }
        public decimal Test45Min { get; set; }
        public decimal MidTermTest { get; set; }
        public decimal FinalTest { get; set; }

        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        public virtual StudentsModel Student { get; set; }
        public virtual SubjectModel Subject { get; set; }
    }
}
