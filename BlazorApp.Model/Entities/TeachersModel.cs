using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{  
    public enum Education
        {
            Master = 1,
            bachelor = 2,
        }
    public enum Sex
    {
        Male = 1,
        Female = 2,
    }
    public class TeachersModel : UserModel
    {
        public int ID { get; set; }
        public string TeacherName { get; set; }
        public Sex Sex { get; set; }
        public Education Education { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Address { get; set; }

        public virtual ICollection<TeachingAssignmentModel> TeachingAssignments { get; set; } = new List<TeachingAssignmentModel>();

        /*public virtual ICollection<ClassModel> Classes { get; set; }= new List<ClassModel>();*/
    }
}
