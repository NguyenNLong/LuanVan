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
    public interface IStudentRepository
    {
        Task<List<StudentsModel>> GetStudents();                 // Lấy danh sách học sinh
        Task<StudentsModel> GetStudent(int id);                  // Lấy học sinh theo ID
		Task<StudentsModel> GetStudentByUserID(int userid);       // Lấy học sinh theo UserID
        Task<StudentsModel> GetStudentsByClass(int classid);       // Lấy học sinh theo UserID

        Task UpdateStudent(StudentsModel studentModel);          // Cập nhật thông tin học sinh
        Task<StudentsModel> CreateStudent(StudentsModel studentModel); // Tạo học sinh mới
        Task<bool> StudentExists(int id);                        // Kiểm tra học sinh có tồn tại không
        Task DeleteStudent(int id);                              // Xóa học sinh
    }
    public class StudentRepository(AppDbContext dbContext) : IStudentRepository
    {
       

        // Phương thức lấy danh sách học sinh
        public Task<List<StudentsModel>> GetStudents()
        {
            return dbContext.Students.ToListAsync();
        }

        // Phương thức lấy học sinh theo ID
        public Task<StudentsModel> GetStudent(int id)
        {
            return dbContext.Students.Include(r => r.Classes).FirstOrDefaultAsync(s => s.ID == id);
        }

		public Task<StudentsModel> GetStudentByUserID(int userid)
		{
			return dbContext.Students.FirstOrDefaultAsync(t => t.UsersID == userid);
		}

		// Phương thức tạo mới học sinh
		public async Task<StudentsModel> CreateStudent(StudentsModel studentModel)
        {
            dbContext.Students.Add(studentModel);
            await dbContext.SaveChangesAsync();
            return studentModel;
        }

        // Phương thức cập nhật thông tin học sinh
        public async Task UpdateStudent(StudentsModel studentModel)
        {
            dbContext.Entry(studentModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        // Phương thức kiểm tra xem học sinh có tồn tại không
        public Task<bool> StudentExists(int id)
        {
            return dbContext.Students.AnyAsync(s => s.ID == id);
        }

        // Phương thức xóa học sinh
        public async Task DeleteStudent(int id)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(s => s.ID == id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task<StudentsModel> GetStudentsByClass(int classid)
        {
            return dbContext.Students.FirstOrDefaultAsync(t => t.ClassesID == classid);
        }
    }
}
