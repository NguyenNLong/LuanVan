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
        Task<ScoresModel> AddScoreAsync(ScoresModel score);
        Task<ScoresModel> UpdateScoreAsync(ScoresModel score);
        Task<IEnumerable<ScoresModel>> GetScoresByClassAndSubjectAsync(int classId, int subjectId, int semesterId);
    }


    public class ScoreRepository(AppDbContext dbContext) : IScoreRepository
    {

        public async Task<ScoresModel> AddScoreAsync(ScoresModel score)
        {
            dbContext.Scores.Add(score);
            await dbContext.SaveChangesAsync();
            return score;
        }
        public async Task<List<ScoresModel>> GetScoresByClassSubjectSemester(int classId, int subjectId, int semesterId)
        {
            var scores = await dbContext.Scores
                .Include(s => s.Subject)
                .Include(s => s.Class)
                .Include(s => s.Semester)
                .Where(s => s.ClassID == classId && s.SubjectID == subjectId && s.SemesterID == semesterId)
                .ToListAsync();

            return scores;
        }
        public async Task<ScoresModel> UpdateScoreAsync(ScoresModel score)
        {
            var existingScore = await dbContext.Scores.FindAsync(score.ID);
            if (existingScore == null) return null;

            existingScore.OralExam = score.OralExam;
            existingScore.FifteenMinExam = score.FifteenMinExam;
            existingScore.OnePeriodExam = score.OnePeriodExam;
            existingScore.MidtermExam = score.MidtermExam;
            existingScore.FinalExam = score.FinalExam;

            await dbContext.SaveChangesAsync();
            return existingScore;
        }

        public async Task<IEnumerable<ScoresModel>> GetScoresByClassAndSubjectAsync(int classId, int subjectId, int semesterId)
        {
            return await dbContext.Scores
                .Where(s => s.ClassID == classId && s.SubjectID == subjectId && s.SemesterID == semesterId)
                .ToListAsync();
        }
    }


}
