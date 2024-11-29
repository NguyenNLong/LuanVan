using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SchoolYearModel
    {
        public int ID { get; set; }
        public string SchoolYearName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public ICollection<SemestersModel> Semesters { get; set; } // Quan hệ 1-N
    }
}
