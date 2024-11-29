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
		public int UserID { get; set; }
        public string ParentName { get; set; }
        public string PAddress { get; set; }
        public string PPhoneNumber { get; set; }
        public string PIdentityNumber { get; set; }
        public string PEmail { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public UserModel User { get; set; } // Quan hệ 1-1 với User
	}
}
