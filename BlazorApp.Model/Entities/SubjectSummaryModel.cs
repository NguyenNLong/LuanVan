using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
	public class SubjectSummaryModel
	{
		public int ID { get; set; }
		public int StudentID { get; set; }
		public virtual StudentsModel Student { get; set; }

		public int SchoolYearID { get; set; }
		public virtual SchoolYearModel SchoolYear { get; set; }

		public int SubjectID { get; set; }
		public virtual SubjectModel Subject { get; set; }

		public int ClassID { get; set; }
		public virtual ClassModel Class { get; set; }

		public double FinalScore { get; set; }
	}
}
