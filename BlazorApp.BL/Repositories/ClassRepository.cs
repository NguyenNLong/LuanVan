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
    public interface IClassRepository
    {
        Task<List<ClassModel>> GetClasses();                  // Lấy danh sách giáo viên
        Task<ClassModel> GetClass(int id);                   // Lấy giáo viên theo ID
        Task<List<ClassModel>> GetClassesByGrade(int gradeId);                   // Lấy giáo viên theo ID

        Task UpdateClass(ClassModel classModel);           // Cập nhật giáo viên
        Task<ClassModel> CreateClass(ClassModel classModel); // Tạo giáo viên mới
        Task<bool> ClassExists(int id);                        // Kiểm tra giáo viên có tồn tại không
        Task DeleteClass(int id);                              // Xóa giáo viên
    }
    public class ClassRepository(AppDbContext dbContext) : IClassRepository
    {
        public Task<bool> ClassExists(int id)
        {
            return dbContext.Classes.AnyAsync(t => t.ID == id);
        }
       
        public async Task<ClassModel> CreateClass(ClassModel classModel)
        {
            dbContext.Classes.Add(classModel);
            await dbContext.SaveChangesAsync();
            return classModel;
        }

        public async Task DeleteClass(int id)
        {
            var classes = await dbContext.Classes.FirstOrDefaultAsync(t => t.ID == id);
            if (classes != null)
            {
                dbContext.Classes.Remove(classes);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task<ClassModel> GetClass(int id)
        {
            return dbContext.Classes.FirstOrDefaultAsync(t => t.ID == id);
        }

        public Task<List<ClassModel>> GetClasses()
        {
            return dbContext.Classes.ToListAsync();
        }

        public Task<List<ClassModel>> GetClassesByGrade(int gradeId)
        {
            return dbContext.Classes
                            .Where(t => t.GradeID == gradeId)
                            .ToListAsync();
        }

        public async Task UpdateClass(ClassModel classModel)
        {
            dbContext.Entry(classModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
