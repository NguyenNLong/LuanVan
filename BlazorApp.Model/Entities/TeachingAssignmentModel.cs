using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class TeachingAssignmentModel
    {
        public int ID { get; set; }  // Khóa chính

        // Thuộc tính năm học và học kỳ
        public string SchoolYear { get; set; }  // Ví dụ: "2023-2024"
        public int Semester { get; set; }  // 1 = Học kỳ 1, 2 = Học kỳ 2

        // Khóa ngoại
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        // Quan hệ với các bảng khác
        public virtual TeachersModel Teacher { get; set; }
        public virtual ClassModel Class { get; set; }
        public virtual SubjectModel Subject { get; set; }
        public virtual ICollection<StudentsModel> Students { get; set; } = new List<StudentsModel>();
    }
}
