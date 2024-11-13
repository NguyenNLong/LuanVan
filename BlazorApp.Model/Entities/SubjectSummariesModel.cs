using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SubjectSummariesModel
    {
        public int ID { get; set; }  // Khóa chính
        public int StudentID { get; set; }  // Khóa ngoại của học sinh
        public int SubjectID { get; set; }  // Khóa ngoại của môn học
        public int Semester { get; set; }  // Học kỳ (1 hoặc 2)
        public decimal FinalScore { get; set; }  // Điểm tổng kết môn học (trung bình điểm của môn trong học kỳ)

        // Quan hệ với bảng học sinh và môn học
        public virtual StudentsModel Student { get; set; }
        public virtual SubjectModel Subject { get; set; }
    }
}
