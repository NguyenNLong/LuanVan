using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ParentModel 
    {
        public int ID { get; set; }
        public string ParentName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public int StudentID { get; set; }
        public int UserID { get; set; }

        public virtual ICollection<StudentsModel> Students { get; set; } = new List<StudentsModel>();
        public virtual UserModel User { get; set; }
    }
}
