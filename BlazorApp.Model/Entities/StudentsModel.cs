using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class StudentsModel : UserModel
    {
        public int ID { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StudentClass { get; set; }
        public string ContactInfo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; } = new List<ClassModel>();
    }
}
