﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class ClassModel
    {
        public int ID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public int GradeID { get; set; }
        public int? HomeroomTeacherID { get; set; }
        public int SchoolYearID { get; set; } // Khóa ngoại
       
        public SchoolYearModel SchoolYear { get; set; } // Navigation property
        public GradeModel Grade { get; set; } = null!;
        public TeachersModel? HomeroomTeacher { get; set; }
    }
}
