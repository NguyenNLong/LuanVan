using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class StudentsModel 
    {
        public int ID { get; set; }
        public string StudentName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? IdentityNumber { get; set; }

        public int ClassID { get; set; }
        public int ParentID { get; set; }
        public int UserID { get; set; }


        public virtual ICollection<ClassModel> Classes { get; set; } = new List<ClassModel>();
        public virtual ICollection<ParentModel> Parents { get; set; } = new List<ParentModel>();
    }
}
