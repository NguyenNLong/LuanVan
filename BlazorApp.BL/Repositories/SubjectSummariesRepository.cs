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
    public interface ISubjectSummariesRepository
    {
        Task<List<SubjectSummariesModel>> GetSubjectSummaries();                 // Lấy danh sách điểm tổng kết môn học
        Task<SubjectSummariesModel> GetSubjectSummary(int id);                   // Lấy điểm tổng kết theo ID
        Task<SubjectSummariesModel> GetSubjectSummaryByStudentAndSubject(int studentId, int subjectId, int semester); // Lấy điểm tổng kết theo học sinh, môn học và học kỳ
        Task<SubjectSummariesModel> CreateSubjectSummary(SubjectSummariesModel subjectSummary); // Tạo điểm tổng kết mới
        Task UpdateSubjectSummary(SubjectSummariesModel subjectSummary);         // Cập nhật điểm tổng kết
        Task<bool> SubjectSummaryExists(int id);                                 // Kiểm tra điểm tổng kết có tồn tại không
        Task DeleteSubjectSummary(int id);                                       // Xóa điểm tổng kết
    }

    public class SubjectSummariesRepository(AppDbContext dbContext) : ISubjectSummariesRepository
    {
        

        public Task<List<SubjectSummariesModel>> GetSubjectSummaries()
        {
            return dbContext.SubjectSummaries
                             .Include(ss => ss.Student)
                             .Include(ss => ss.Subject)
                             .ToListAsync();
        }

        public Task<SubjectSummariesModel> GetSubjectSummary(int id)
        {
            return dbContext.SubjectSummaries
                             .Include(ss => ss.Student)
                             .Include(ss => ss.Subject)
                             .FirstOrDefaultAsync(ss => ss.ID == id);
        }

        public Task<SubjectSummariesModel> GetSubjectSummaryByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            return dbContext.SubjectSummaries
                             .Include(ss => ss.Student)
                             .Include(ss => ss.Subject)
                             .FirstOrDefaultAsync(ss => ss.StudentID == studentId && ss.SubjectID == subjectId && ss.Semester == semester);
        }

        public async Task<SubjectSummariesModel> CreateSubjectSummary(SubjectSummariesModel subjectSummary)
        {
            await dbContext.SubjectSummaries.AddAsync(subjectSummary);
            await dbContext.SaveChangesAsync();
            return subjectSummary;
        }

        public async Task UpdateSubjectSummary(SubjectSummariesModel subjectSummary)
        {
            dbContext.Entry(subjectSummary).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public Task<bool> SubjectSummaryExists(int id)
        {
            return dbContext.SubjectSummaries.AnyAsync(ss => ss.ID == id);
        }

        public async Task DeleteSubjectSummary(int id)
        {
            var subjectSummary = await dbContext.SubjectSummaries.FirstOrDefaultAsync(ss => ss.ID == id);
            if (subjectSummary != null)
            {
                dbContext.SubjectSummaries.Remove(subjectSummary);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
