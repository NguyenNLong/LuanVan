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
        Task<List<GradeModel>> GetGrades();                          // Lấy danh sách khối lớp
        Task<GradeModel> GetGrade(int id);                            // Lấy khối lớp theo ID
        Task<GradeModel> CreateGrade(GradeModel grade);               // Tạo mới khối lớp
        Task UpdateGrade(GradeModel grade);                           // Cập nhật thông tin khối lớp
        Task<bool> GradeExists(int id);                               // Kiểm tra khối lớp có tồn tại không
        Task DeleteGrade(int id);                                     // Xóa khối lớp
    }

    public class GradeRepository(AppDbContext dbContext) : IGradeRepository
    {
       

        public Task<List<GradeModel>> GetGrades()
        {
            return dbContext.Grades.Include(g => g.Classes).ToListAsync();
        }

        public Task<GradeModel> GetGrade(int id)
        {
            return dbContext.Grades
                             .Include(g => g.Classes)
                             .FirstOrDefaultAsync(g => g.ID == id);
        }

        public async Task<GradeModel> CreateGrade(GradeModel grade)
        {
            await dbContext.Grades.AddAsync(grade);
            await dbContext.SaveChangesAsync();
            return grade;
        }

        public async Task UpdateGrade(GradeModel grade)
        {
            dbContext.Entry(grade).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public Task<bool> GradeExists(int id)
        {
            return dbContext.Grades.AnyAsync(g => g.ID == id);
        }

        public async Task DeleteGrade(int id)
        {
            var grade = await dbContext.Grades.FirstOrDefaultAsync(g => g.ID == id);
            if (grade != null)
            {
                dbContext.Grades.Remove(grade);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
