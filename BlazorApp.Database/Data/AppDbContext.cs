using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RefreshTokenModel> RefreshTokens { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<TeachersModel> Teachers { get; set; }
        public DbSet<StudentsModel> Students { get; set; }
        public DbSet<ParentModel> Parents { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<ScoresModel> Scores { get; set; }
        public DbSet<TeachingAssignmentModel> TeachingAssignments { get; set; }
        public DbSet<NotificationModel> Notifications { get; set; }
        public DbSet<SchoolYearModel> SchoolYears { get; set; }
        public DbSet<AnnualScoreModel> AnnualScores { get; set; }
        public DbSet<SemestersModel> Semesters { get; set; }
        public DbSet<SubjectSummaryModel> SubjectSummaries { get; set; }
        
    }
}
