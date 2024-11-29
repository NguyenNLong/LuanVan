using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class SubjectModel
    {
        public int ID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public int Coefficient { get; set; } // 1 or 2    
    }
}
