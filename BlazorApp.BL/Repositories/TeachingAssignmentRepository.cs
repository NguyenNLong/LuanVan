/*using BlazorApp.Database.Data;
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
        Task<List<SchoolYearModel>> GetTeachingAssignments();                            // Lấy danh sách phân công giảng dạy
        Task<SchoolYearModel> GetTeachingAssignment(int id);                             // Lấy phân công theo ID
        Task<SchoolYearModel> CreateTeachingAssignment(SchoolYearModel assignment); // Tạo mới phân công giảng dạy
        Task UpdateTeachingAssignment(SchoolYearModel assignment);                       // Cập nhật phân công giảng dạy
        Task<bool> TeachingAssignmentExists(int id);                                             // Kiểm tra phân công có tồn tại không
        Task DeleteTeachingAssignment(int id);                                                   // Xóa phân công giảng dạy
    }

    public class TeachingAssignmentRepository(AppDbContext dbContext) : ITeachingAssignmentRepository
    {


        public Task<List<SchoolYearModel>> GetTeachingAssignments()
        {
            return dbContext.TeachingAssignments
                             .Include(ta => ta.Teacher)
                             .Include(ta => ta.Class)
                             .Include(ta => ta.Subject)
                             .Include(ta => ta.Students)
                             .ToListAsync();
        }

        public Task<SchoolYearModel> GetTeachingAssignment(int id)
        {
            return dbContext.TeachingAssignments
                             .Include(ta => ta.Teacher)
                             .Include(ta => ta.Class)
                             .Include(ta => ta.Subject)
                             .Include(ta => ta.Students)
                             .FirstOrDefaultAsync(ta => ta.ID == id);
        }

        public async Task<SchoolYearModel> CreateTeachingAssignment(SchoolYearModel assignment)
        {
            await dbContext.TeachingAssignments.AddAsync(assignment);
            await dbContext.SaveChangesAsync();
            return assignment;
        }

        public async Task UpdateTeachingAssignment(SchoolYearModel assignment)
        {
            dbContext.Entry(assignment).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public Task<bool> TeachingAssignmentExists(int id)
        {
            return dbContext.TeachingAssignments.AnyAsync(ta => ta.ID == id);
        }

        public async Task DeleteTeachingAssignment(int id)
        {
            var assignment = await dbContext.TeachingAssignments.FirstOrDefaultAsync(ta => ta.ID == id);
            if (assignment != null)
            {
                dbContext.TeachingAssignments.Remove(assignment);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
*/