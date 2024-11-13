using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IScoresService
    {
        Task<List<ScoresModel>> GetScores();                          // Lấy danh sách điểm
        Task<ScoresModel> GetScore(int id);                            // Lấy điểm theo ID
        Task<ScoresModel> GetScoreByStudentAndSubject(int studentId, int subjectId, int semester); // Lấy điểm của học sinh theo môn học và học kỳ
        Task UpdateScore(ScoresModel scoresModel);                     // Cập nhật điểm
        Task<ScoresModel> CreateScore(ScoresModel scoresModel);        // Tạo điểm mới
        Task<bool> ScoreExists(int id);                                // Kiểm tra điểm có tồn tại không
        Task DeleteScore(int id);                                      // Xóa điểm
    }

    public class ScoresService : IScoresService
    {
        private readonly IScoreRepository _scoresRepository;

        // Constructor nhận vào IScoresRepository qua dependency injection
        public ScoresService(IScoreRepository scoresRepository)
        {
            _scoresRepository = scoresRepository;
        }

        // Lấy danh sách điểm
        public Task<List<ScoresModel>> GetScores()
        {
            return _scoresRepository.GetScores();
        }

        // Lấy điểm theo ID
        public Task<ScoresModel> GetScore(int id)
        {
            return _scoresRepository.GetScore(id);
        }

        // Lấy điểm của học sinh theo môn học và học kỳ
        public Task<ScoresModel> GetScoreByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            return _scoresRepository.GetScoreByStudentAndSubject(studentId, subjectId, semester);
        }

        // Cập nhật thông tin điểm
        public Task UpdateScore(ScoresModel scoresModel)
        {
            return _scoresRepository.UpdateScore(scoresModel);
        }

        // Tạo điểm mới
        public Task<ScoresModel> CreateScore(ScoresModel scoresModel)
        {
            return _scoresRepository.CreateScore(scoresModel);
        }

        // Kiểm tra xem điểm có tồn tại không
        public Task<bool> ScoreExists(int id)
        {
            return _scoresRepository.ScoreExists(id);
        }

        // Xóa điểm
        public Task DeleteScore(int id)
        {
            return _scoresRepository.DeleteScore(id);
        }
    }
}
