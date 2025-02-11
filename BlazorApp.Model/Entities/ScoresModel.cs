using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ScoresModel
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int ClassID { get; set; }
        public int SemesterID { get; set; }
        public int SchoolYearID { get; set; }
        public float OralExam { get; set; }
        public float FifteenMinExam { get; set; }
        public float OnePeriodExam { get; set; }
        public float MidtermExam { get; set; }
        public float FinalExam { get; set; }

        // Cột tính toán - không cần lưu trữ
        public float AverageScore =>
            (OralExam + FifteenMinExam + OnePeriodExam * 2 + MidtermExam * 2 + FinalExam * 2) / 8;

        public virtual ICollection<StudentsModel> Student { get; set; } = null!;
        public virtual ICollection<SubjectModel> Subject { get; set; } = null!;
        public virtual ICollection<ClassModel> Classes { get; set; } = null!;
        public virtual SchoolYearModel SchoolYear { get; set; } = null!;
        public virtual SemestersModel Semester { get; set; } = null!;
    }
}
