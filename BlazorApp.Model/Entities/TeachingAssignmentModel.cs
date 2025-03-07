﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Model.Entities
{
    public class TeachingAssignmentModel
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public int ClassID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
       


        public TeachersModel Teacher { get; set; } = null!;
        public SubjectModel Subject { get; set; } = null!;
        public ClassModel Class { get; set; } = null!;
        public SchoolYearModel SchoolYear { get; set; }
        public SemestersModel Semesters { get; set; }
    }
}
