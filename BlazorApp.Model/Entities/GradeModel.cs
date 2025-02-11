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
        public string GradeName { get; set; } = string.Empty;

        // Navigation property để mô tả quan hệ 1:N giữa Grade và Class
        public virtual ICollection<ClassModel> Classes { get; set; } = new List<ClassModel>();

    }
}
