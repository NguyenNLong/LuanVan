using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
   
        public class AnnualScoreModel
        {
            public int ID { get; set; }
            public int StudentID { get; set; }
            public int SubjectID { get; set; }
            public int ClassID { get; set; }
            public string AcademicYear { get; set; }
            public float AverageFirstSemester { get; set; }
            public float AverageSecondSemester { get; set; }

            // Cột tính toán - không cần lưu trữ
            public float AnnualAverageScore => (AverageFirstSemester + AverageSecondSemester) / 2;

            // Navigation properties
            public StudentsModel Student { get; set; }
            public SubjectModel Subject { get; set; }
            public ClassModel Class { get; set; }
        }

    
}
