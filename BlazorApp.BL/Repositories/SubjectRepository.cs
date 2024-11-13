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
    public interface ISubjectRepository
    {
        Task<List<SubjectModel>> GetSubjects();                    // Lấy danh sách môn học
        Task<SubjectModel> GetSubject(int id);                     // Lấy môn học theo ID
        Task<SubjectModel> CreateSubject(SubjectModel subjectModel); // Tạo môn học mới
        Task UpdateSubject(SubjectModel subjectModel);             // Cập nhật môn học
        Task<bool> SubjectExists(int id);                           // Kiểm tra môn học có tồn tại không
        Task DeleteSubject(int id);                                 // Xóa môn học
    }

    public class SubjectRepository(AppDbContext dbContext) : ISubjectRepository
    {



        // Phương thức lấy danh sách môn học
        public Task<List<SubjectModel>> GetSubjects()
        {
            return dbContext.Subjects.ToListAsync();
        }

      

        // Phương thức lấy môn học theo ID
        public Task<SubjectModel> GetSubject(int id)
        {
            return dbContext.Subjects.FirstOrDefaultAsync(s => s.ID == id);
        }

        // Phương thức tạo mới môn học
        public async Task<SubjectModel> CreateSubject(SubjectModel subjectModel)
        {
            dbContext.Subjects.Add(subjectModel);
            await dbContext.SaveChangesAsync();
            return subjectModel;
        }

        // Phương thức cập nhật môn học
        public async Task UpdateSubject(SubjectModel subjectModel)
        {
            dbContext.Entry(subjectModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        // Phương thức kiểm tra xem môn học có tồn tại không
        public Task<bool> SubjectExists(int id)
        {
            return dbContext.Subjects.AnyAsync(s => s.ID == id);
        }

        // Phương thức xóa môn học
        public async Task DeleteSubject(int id)
        {
            var subject = await dbContext.Subjects.FirstOrDefaultAsync(s => s.ID == id);
            if (subject != null)
            {
                dbContext.Subjects.Remove(subject);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
