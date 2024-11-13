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
    public interface IScoreRepository
    {
        Task<List<ScoresModel>> GetScores();                           // Lấy danh sách điểm số
        Task<ScoresModel> GetScore(int id);                             // Lấy điểm số theo ID
        Task<ScoresModel> GetScoreByStudentAndSubject(int studentId, int subjectId, int semester); // Lấy điểm số của học sinh cho môn học trong học kỳ
        Task<ScoresModel> CreateScore(ScoresModel scoresModel);        // Tạo điểm số mới
        Task UpdateScore(ScoresModel scoresModel);                     // Cập nhật điểm số
        Task<bool> ScoreExists(int id);                                // Kiểm tra điểm số có tồn tại không
        Task DeleteScore(int id);                                      // Xóa điểm số
    }
    public class ScoreRepository : IScoreRepository
    {
        private readonly AppDbContext _dbContext;

        // Constructor nhận vào AppDbContext qua dependency injection
        public ScoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Phương thức lấy danh sách tất cả điểm số
        public Task<List<ScoresModel>> GetScores()
        {
            return _dbContext.Scores
                             .Include(s => s.Student) // Nếu có quan hệ với bảng StudentsModel
                             .Include(s => s.Subject) // Nếu có quan hệ với bảng SubjectModel
                             .ToListAsync();
        }

        // Phương thức lấy điểm số theo ID
        public Task<ScoresModel> GetScore(int id)
        {
            return _dbContext.Scores
                             .Include(s => s.Student) // Nếu có quan hệ với bảng StudentsModel
                             .Include(s => s.Subject) // Nếu có quan hệ với bảng SubjectModel
                             .FirstOrDefaultAsync(s => s.ID == id);
        }

        // Phương thức lấy điểm số của học sinh cho môn học trong học kỳ
        public Task<ScoresModel> GetScoreByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            return _dbContext.Scores
                             .Include(s => s.Student) // Nếu có quan hệ với bảng StudentsModel
                             .Include(s => s.Subject) // Nếu có quan hệ với bảng SubjectModel
                             .FirstOrDefaultAsync(s => s.StudentID == studentId && s.SubjectID == subjectId && s.Semester == semester);
        }

        // Phương thức tạo điểm số mới
        public async Task<ScoresModel> CreateScore(ScoresModel scoresModel)
        {
            await _dbContext.Scores.AddAsync(scoresModel);
            await _dbContext.SaveChangesAsync();
            return scoresModel;
        }

        // Phương thức cập nhật điểm số
        public async Task UpdateScore(ScoresModel scoresModel)
        {
            _dbContext.Entry(scoresModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Kiểm tra điểm số có tồn tại không
        public Task<bool> ScoreExists(int id)
        {
            return _dbContext.Scores.AnyAsync(s => s.ID == id);
        }

        // Phương thức xóa điểm số
        public async Task DeleteScore(int id)
        {
            var score = await _dbContext.Scores.FirstOrDefaultAsync(s => s.ID == id);
            if (score != null)
            {
                _dbContext.Scores.Remove(score);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
