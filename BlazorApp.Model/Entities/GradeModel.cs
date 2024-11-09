using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
	public class GradeModel
	{
		public int ID { get; set; }
		public string NameGrade { get; set; }

		public int ClassID { get; set; }

		public virtual ICollection<ClassModel> Classes { get; set; } = new List<ClassModel>();

	}
}
