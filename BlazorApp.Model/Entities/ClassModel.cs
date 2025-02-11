using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ClassModel
    {
        public int ID { get; set; }
        public string ClassName { get; set; } = string.Empty;

        // Khóa ngoại liên kết với Grade
        public int GradeID { get; set; }
        public virtual GradeModel Grade { get; set; } = null!;

        // Khóa ngoại liên kết với SchoolYear
        public int SchoolYearID { get; set; }
        public virtual SchoolYearModel SchoolYear { get; set; } = null!;

        // Giáo viên chủ nhiệm (nếu có)
        public int? HomeroomTeacherID { get; set; }
        public virtual TeachersModel? HomeroomTeacher { get; set; }
    }
}
