using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ClassModel
    {
        public int ID { get; set; }  // Khóa chính
        public string ClassName { get; set; }  // Tên lớp
        public string SchoolYear { get; set; }  // Năm học (ví dụ: "2023-2024")

        public int TeacherId { get; set; }  // Khóa ngoại của giáo viên chủ nhiệm (nếu có)
        public int GradeID { get; set; }

        // Quan hệ với các bảng khác
        //public virtual TeachersModel HomeroomTeacher { get; set; }  // Giáo viên chủ nhiệm
        public virtual ICollection<StudentsModel> Students { get; set; } = new List<StudentsModel>();  // Danh sách học sinh trong lớp
        public virtual GradeModel Grade { get; set; }
    }
}
