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
		public int UsersID { get; set; }
		public int ClassesID { get; set; } // Lớp trong năm học hiện tại
		public int? ParentsID { get; set; }

		public string StudentName { get; set; }
        public string SAddress { get; set; }
        public string SPhoneNumber { get; set; }
        public string SIdentityNumber { get; set; }
		public string SEmail {  get; set; }
		public DateOnly DateOfBirth { get; set; }

        public string ParentContactInfo { get; set; } // Thông tin liên hệ phụ huynh
		public string StatusStudent { get; set; } // Trạng thái học sinh

        // Quan hệ
        public virtual UserModel Users { get; set; }
        public virtual ClassModel Classes { get; set; }
		public virtual ParentModel Parents { get; set; }
	}
}
