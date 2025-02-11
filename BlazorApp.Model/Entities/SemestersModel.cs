using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SemestersModel
    {
        public int ID { get; set; }
        public string SemesterName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SchoolYearID { get; set; }
        public virtual SchoolYearModel SchoolYear { get; set; } 
    }
}
