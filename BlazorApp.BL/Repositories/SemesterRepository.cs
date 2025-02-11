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
    public interface ISemesterRepository
    {
        Task<List<SemestersModel>> GetSemester();
        Task<SemestersModel> GetSemesterById(int id);
        Task<List<SemestersModel>> GetSemestersByYearId(int YearId);
        Task UpdateSemeter(SemestersModel semesterModel);
        Task<SemestersModel> CreateSemester(SemestersModel semesterModel);
        Task<bool> SemeterExists(int id);
        Task DeleteSemeter(int id);
    }
    public class SemesterRepository(AppDbContext dbContext) : ISemesterRepository
    {
        public async Task<SemestersModel> CreateSemester(SemestersModel semesterModel)
        {
            dbContext.Semesters.Add(semesterModel);
            await dbContext.SaveChangesAsync();
            return semesterModel;
        }

        public async Task DeleteSemeter(int id)
        {
            var semesters = await dbContext.Semesters.FirstOrDefaultAsync(t => t.ID == id);
            if (semesters != null)
            {
                dbContext.Semesters.Remove(semesters);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task<List<SemestersModel>> GetSemester()
        {
            return dbContext.Semesters.ToListAsync();
        }

        public Task<SemestersModel> GetSemesterById(int id)
        {
            return dbContext.Semesters.FirstOrDefaultAsync(t => t.ID == id);
        }

        public Task<bool> SemeterExists(int id)
        {
            return dbContext.Semesters.AnyAsync(t => t.ID == id);
        }

        public async Task UpdateSemeter(SemestersModel semesterModel)
        {
            dbContext.Entry(semesterModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<SemestersModel>> GetSemestersByYearId(int YearId)
        {
            return await dbContext.Semesters
                .Where(s => s.SchoolYearID == YearId)
                .ToListAsync();
        }
    }
}