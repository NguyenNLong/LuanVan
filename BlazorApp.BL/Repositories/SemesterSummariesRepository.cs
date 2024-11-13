using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorApp.BL.Repositories.SemesterSummariesRepository;

namespace BlazorApp.BL.Repositories
{
    public interface ISemesterSummariesRepository
    {
        Task<List<SemesterSummariesModel>> GetSemesterSummaries();               // Lấy tất cả tổng kết học kỳ
        Task<SemesterSummariesModel> GetSemesterSummary(int id);                 // Lấy tổng kết học kỳ theo ID
        Task<List<SemesterSummariesModel>> GetSemesterSummariesByStudent(int studentId); // Lấy tổng kết học kỳ theo ID học sinh
        Task<SemesterSummariesModel> CreateSemesterSummary(SemesterSummariesModel summary); // Tạo mới tổng kết học kỳ
        Task UpdateSemesterSummary(SemesterSummariesModel summary);              // Cập nhật tổng kết học kỳ
        Task<bool> SemesterSummaryExists(int id);                                // Kiểm tra tổng kết học kỳ có tồn tại không
        Task DeleteSemesterSummary(int id);                                      // Xóa tổng kết học kỳ
    }
    public class SemesterSummariesRepository(AppDbContext dbContext) : ISemesterSummariesRepository
    {
        public Task<List<SemesterSummariesModel>> GetSemesterSummaries()
        {
            return dbContext.SemesterSummaries
                             .Include(s => s.Student)
                             .ToListAsync();
        }

        public Task<SemesterSummariesModel> GetSemesterSummary(int id)
        {
            return dbContext.SemesterSummaries
                             .Include(s => s.Student)
                             .FirstOrDefaultAsync(s => s.ID == id);
        }

        public Task<List<SemesterSummariesModel>> GetSemesterSummariesByStudent(int studentId)
        {
            return dbContext.SemesterSummaries
                             .Where(s => s.StudentID == studentId)
                             .Include(s => s.Student)
                             .ToListAsync();
        }

        public async Task<SemesterSummariesModel> CreateSemesterSummary(SemesterSummariesModel summary)
        {
            await dbContext.SemesterSummaries.AddAsync(summary);
            await dbContext.SaveChangesAsync();
            return summary;
        }

        public async Task UpdateSemesterSummary(SemesterSummariesModel summary)
        {
            dbContext.Entry(summary).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public Task<bool> SemesterSummaryExists(int id)
        {
            return dbContext.SemesterSummaries.AnyAsync(s => s.ID == id);
        }

        public async Task DeleteSemesterSummary(int id)
        {
            var summary = await dbContext.SemesterSummaries.FirstOrDefaultAsync(s => s.ID == id);
            if (summary != null)
            {
                dbContext.SemesterSummaries.Remove(summary);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
