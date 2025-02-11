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
    public interface ITeachingAssignmentRepository
    {
        Task<List<TeachingAssignmentModel>> GetAllAssignments();               // Lấy tất cả phân công
        Task<List<TeachingAssignmentModel>> GetAssignmentsByYear(int schoolYearId); // Lấy phân công theo năm học
        Task<TeachingAssignmentModel> GetAssignmentById(int id);               // Lấy phân công theo ID
        Task<TeachingAssignmentModel> AddAssignment(TeachingAssignmentModel assignment); // Thêm phân công
        Task UpdateAssignment(TeachingAssignmentModel assignment);             // Cập nhật phân công
        Task DeleteAssignment(int id);                                         // Xóa phân công
        Task<bool> AssignmentExists(int id);                                   // Kiểm tra phân công có tồn tại không
    }
    public class TeachingAssignmentRepository(AppDbContext dbContext) : ITeachingAssignmentRepository
    {
      

        public async Task<List<TeachingAssignmentModel>> GetAllAssignments()
        {
            return await dbContext.TeachingAssignments
                .Include(ta => ta.Teacher)
                .Include(ta => ta.Class)
                .Include(ta => ta.Subject)
                .Include(ta => ta.SchoolYear)
                .ToListAsync();
        }

        public async Task<List<TeachingAssignmentModel>> GetAssignmentsByYear(int schoolYearId)
        {
            return await dbContext.TeachingAssignments
                .Include(ta => ta.Teacher)
                .Include(ta => ta.Class)
                .Include(ta => ta.Subject)
                .Include(ta => ta.SchoolYear)
                .Where(ta => ta.SchoolYearID == schoolYearId)
                .ToListAsync();
        }

        public async Task<TeachingAssignmentModel> GetAssignmentById(int id)
        {
            return await dbContext.TeachingAssignments
                .Include(ta => ta.Teacher)
                .Include(ta => ta.Class)
                .Include(ta => ta.Subject)
                .Include(ta => ta.SchoolYear)
                .FirstOrDefaultAsync(ta => ta.ID == id);
        }

        public async Task<TeachingAssignmentModel> AddAssignment(TeachingAssignmentModel assignment)
        {
            dbContext.TeachingAssignments.Add(assignment);
            await dbContext.SaveChangesAsync();
            return assignment;
        }

        public async Task UpdateAssignment(TeachingAssignmentModel assignment)
        {
            dbContext.Entry(assignment).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAssignment(int id)
        {
            var assignment = await dbContext.TeachingAssignments.FindAsync(id);
            if (assignment != null)
            {
                dbContext.TeachingAssignments.Remove(assignment);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task<bool> AssignmentExists(int id)
        {
            return dbContext.TeachingAssignments.AnyAsync(ta => ta.ID == id);
        }
    }

}
