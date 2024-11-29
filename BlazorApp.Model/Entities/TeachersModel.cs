using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public enum Gender 
    {
        Male = 1, Female = 2 
    }
    public enum Education
    {
        Master = 1 , Bachelor = 2
    }
    public class TeachersModel 
    {
        public int ID { get; set; }
        public string TeacherName { get; set; }
        public string TPhoneNumber { get; set; }
        public string TEmail { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string TIdentityNumber { get; set; }
        public string TAddress { get; set; }
        public Gender Gender { get; set; }

        public string? Specialization { get; set; }
        public Education Education { get; set; }
        public string StatusTeacher { get; set; } // Trạng thái giao vien


        public int UsersID { get; set; }

        // Navigation property
        public virtual UserModel Users { get; set; }


    }
}
