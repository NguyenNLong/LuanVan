using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Repositories
{
    
    public interface IGradeRepository
    {
        Task<List<GradeModel>> GetGrades();
        Task<GradeModel> GetGradeById(int id);


        Task<GradeModel> CreateGrade(GradeModel gradeModel);

    }
    public class GradeRepository(AppDbContext dbContext) : IGradeRepository
    {
        public async Task<GradeModel> CreateGrade(GradeModel gradeModel)
        {
            dbContext.Grades.Add(gradeModel);
            await dbContext.SaveChangesAsync();
            return gradeModel;
        }

        

        public Task<GradeModel> GetGradeById(int id)
        {
            return dbContext.Grades.FirstOrDefaultAsync(t => t.ID == id);
        }

        public Task<List<GradeModel>> GetGrades()
        {
            return dbContext.Grades.ToListAsync();
        }

        

        
    }
}
