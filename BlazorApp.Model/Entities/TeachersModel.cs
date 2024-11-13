using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{  
    public enum EducationStatus
    {
            Master = 1,
            bachelor = 2,
        }
    public enum SexStatus
    {
        Male = 1,
        Female = 2,
    }
    public class TeachersModel 
    {
        public int ID { get; set; }
        public string TeacherName { get; set; }
        public SexStatus Sex { get; set; }
        public EducationStatus Education { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Address { get; set; }



        public int UserID { get; set; }
        public int TeachingAssignmentID { get; set; }
        public int ClassID { get; set; }


        //  public virtual ClassModel HomeroomClasses { get; set; }lớp giáo viên làm chủ nhiệm
        public virtual ICollection<TeachingAssignmentModel> TeachingAssignments { get; set; } = new List<TeachingAssignmentModel>();

        public virtual ICollection<ClassModel> Classes { get; set; } = new List<ClassModel>();
        public virtual SubjectModel Subjects { get; set; }  //  môn mà giáo viên dạy

    }
}
