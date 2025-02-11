using BlazorApp.BL.Repositories;
using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IScoreService
    {
        Task<ScoresModel> AddScoreAsync(ScoresModel score);
        Task<ScoresModel> UpdateScoreAsync(ScoresModel score);
        Task<IEnumerable<ScoresModel>> GetScoresByClassAndSubjectAsync(int classId, int subjectId, int semesterId);
    }

    public class ScoreService(IScoreRepository scoreRepository) : IScoreService
    {
        
       

        public async Task<ScoresModel> AddScoreAsync(ScoresModel score)
        {
            
            if (score == null || score.StudentID <= 0 || score.SubjectID <= 0 || score.ClassID <= 0
                || score.SchoolYearID <= 0 || score.SemesterID <= 0)
                throw new ArgumentException("Invalid score data");

            return await scoreRepository.AddScoreAsync(score);
        }

        public async Task<ScoresModel> UpdateScoreAsync(ScoresModel score)
        {
            var updatedScore = await scoreRepository.UpdateScoreAsync(score);
            if (updatedScore == null)
                throw new Exception("Score not found or update failed");

            return updatedScore;
        }

        public async Task<IEnumerable<ScoresModel>> GetScoresByClassAndSubjectAsync(int classId, int subjectId, int semesterId)
        {
            return await scoreRepository.GetScoresByClassAndSubjectAsync(classId, subjectId, semesterId);
        }
    }


}
