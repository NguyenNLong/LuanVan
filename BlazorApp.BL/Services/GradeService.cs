using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IGradeService
    {
        Task<List<GradeModel>> GetGrades();                  // Lấy danh sách Grade
        Task<GradeModel> GetGradeById(int id);                   // Lấy Grade theo ID
        Task<GradeModel> CreateGrade(GradeModel gradeModel); // Tạo Grade mới
    }
    public class GradeService(IGradeRepository gradeRepository) : IGradeService
    {
        public Task<GradeModel> CreateGrade(GradeModel gradeModel)
        {
            return gradeRepository.CreateGrade(gradeModel);
        }

        public Task<GradeModel> GetGradeById(int id)
        {
            return gradeRepository.GetGradeById(id);
        }

        public Task<List<GradeModel>> GetGrades()
        {
            return gradeRepository.GetGrades();
        }
    }
}
