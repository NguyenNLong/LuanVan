using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SubjectModel
    {
        public int ID { get; set; }  // Khóa chính
        public string SubjectName { get; set; }  // Tên môn học (ví dụ: "Toán", "Văn", "Anh Văn")
        public int Coefficient { get; set; }  // Hệ số môn học (1 hoặc 2)

        // Quan hệ với các bảng khác
        public virtual ICollection<TeachingAssignmentModel> TeachingAssignments { get; set; } = new List<TeachingAssignmentModel>(); // Danh sách phân công giảng dạy môn học này
        public virtual ICollection<TeachersModel> Teachers { get; set; } = new List<TeachersModel>();  // Các giáo viên dạy môn này
        public virtual ICollection<ScoresModel> Scores { get; set; } = new List<ScoresModel>();  // Các điểm của môn học này
    }
}
