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
        Task<List<GradeModel>> GetGrades();                          // Lấy danh sách khối
        Task<GradeModel> GetGrade(int id);                            // Lấy khối theo ID
        Task<GradeModel> CreateGrade(GradeModel grade);               // Tạo mới khối
        Task UpdateGrade(GradeModel grade);                           // Cập nhật khối
        Task<bool> GradeExists(int id);                               // Kiểm tra khối có tồn tại không
        Task DeleteGrade(int id);                                     // Xóa khối
    }

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Task<List<GradeModel>> GetGrades()
        {
            return _gradeRepository.GetGrades();
        }

        public Task<GradeModel> GetGrade(int id)
        {
            return _gradeRepository.GetGrade(id);
        }

        public Task<GradeModel> CreateGrade(GradeModel grade)
        {
            return _gradeRepository.CreateGrade(grade);
        }

        public Task UpdateGrade(GradeModel grade)
        {
            return _gradeRepository.UpdateGrade(grade);
        }

        public Task<bool> GradeExists(int id)
        {
            return _gradeRepository.GradeExists(id);
        }

        public Task DeleteGrade(int id)
        {
            return _gradeRepository.DeleteGrade(id);
        }
    }
}
