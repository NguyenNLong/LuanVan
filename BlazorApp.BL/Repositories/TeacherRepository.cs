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
    public interface ITeacherRepository
    {
        Task<List<TeachersModel>> GetTeachers();                  // Lấy danh sách giáo viên
        Task<TeachersModel> GetTeacher(int id);                   // Lấy giáo viên theo ID
        Task UpdateTeacher(TeachersModel teacherModel);           // Cập nhật giáo viên
        Task<TeachersModel> CreateTeacher(TeachersModel teacherModel); // Tạo giáo viên mới
        Task<bool> TeacherExists(int id);                        // Kiểm tra giáo viên có tồn tại không
        Task DeleteTeacher(int id);                              // Xóa giáo viên
    }

    public class TeacherRepository(AppDbContext dbContext) : ITeacherRepository
    {
        

        // Phương thức lấy danh sách giáo viên
        public Task<List<TeachersModel>> GetTeachers()
        {
            return dbContext.Teachers.ToListAsync();
        }

        // Phương thức lấy giáo viên theo ID
        public Task<TeachersModel> GetTeacher(int id)
        {
            return dbContext.Teachers.FirstOrDefaultAsync(t => t.ID == id);
        }

        // Phương thức tạo mới giáo viên
        public async Task<TeachersModel> CreateTeacher(TeachersModel teacherModel)
        {
            dbContext.Teachers.Add(teacherModel);
            await dbContext.SaveChangesAsync();
            return teacherModel;
        }

        // Phương thức cập nhật giáo viên
        public async Task UpdateTeacher(TeachersModel teacherModel)
        {
            dbContext.Entry(teacherModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        // Phương thức kiểm tra xem giáo viên có tồn tại không
        public Task<bool> TeacherExists(int id)
        {
            return dbContext.Teachers.AnyAsync(t => t.ID == id);
        }

        // Phương thức xóa giáo viên
        public async Task DeleteTeacher(int id)
        {
            var teacher = await dbContext.Teachers.FirstOrDefaultAsync(t => t.ID == id);
            if (teacher != null)
            {
                dbContext.Teachers.Remove(teacher);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
