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
    public interface ISubjectSummaryRepository
    {
        Task<List<SubjectSummaryModel>> GetSubjectSummaries(int studentId, int semesterId);
        Task<SubjectSummaryModel> GetById(int id);
        Task Create(SubjectSummaryModel subjectSummary);
        Task Update(SubjectSummaryModel subjectSummary);
        Task Delete(int id);
    }

    public class SubjectSummaryRepository(AppDbContext dbContext) : ISubjectSummaryRepository
    {
        

        public async Task<List<SubjectSummaryModel>> GetSubjectSummaries(int studentId, int schoolyearId)
        {
            return await dbContext.SubjectSummaries
                .Where(ss => ss.StudentID == studentId && ss.SchoolYearID == schoolyearId)
                .Include(ss => ss.Subject)
                .ToListAsync();
        }

        public async Task<SubjectSummaryModel> GetById(int id)
        {
            return await dbContext.SubjectSummaries
                .Include(ss => ss.Subject)
                .FirstOrDefaultAsync(ss => ss.ID == id);
        }

        public async Task Create(SubjectSummaryModel subjectSummary)
        {
            await dbContext.SubjectSummaries.AddAsync(subjectSummary);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(SubjectSummaryModel subjectSummary)
        {
            dbContext.SubjectSummaries.Update(subjectSummary);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                dbContext.SubjectSummaries.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
    }

}
