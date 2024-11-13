using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ISubjectSummariesService
    {
        Task<List<SubjectSummariesModel>> GetSubjectSummaries();                          // Lấy danh sách điểm tổng kết môn học
        Task<SubjectSummariesModel> GetSubjectSummary(int id);                            // Lấy điểm tổng kết theo ID
        Task<SubjectSummariesModel> GetSubjectSummaryByStudentAndSubject(int studentId, int subjectId, int semester); // Lấy điểm tổng kết theo học sinh, môn học, học kỳ
        Task UpdateSubjectSummary(SubjectSummariesModel subjectSummary);                  // Cập nhật điểm tổng kết
        Task<SubjectSummariesModel> CreateSubjectSummary(SubjectSummariesModel subjectSummary); // Tạo mới điểm tổng kết
        Task<bool> SubjectSummaryExists(int id);                                          // Kiểm tra điểm tổng kết có tồn tại không
        Task DeleteSubjectSummary(int id);                                                // Xóa điểm tổng kết
    }

    public class SubjectSummariesService : ISubjectSummariesService
    {
        private readonly ISubjectSummariesRepository _subjectSummariesRepository;

        public SubjectSummariesService(ISubjectSummariesRepository subjectSummariesRepository)
        {
            _subjectSummariesRepository = subjectSummariesRepository;
        }

        public Task<List<SubjectSummariesModel>> GetSubjectSummaries()
        {
            return _subjectSummariesRepository.GetSubjectSummaries();
        }

        public Task<SubjectSummariesModel> GetSubjectSummary(int id)
        {
            return _subjectSummariesRepository.GetSubjectSummary(id);
        }

        public Task<SubjectSummariesModel> GetSubjectSummaryByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            return _subjectSummariesRepository.GetSubjectSummaryByStudentAndSubject(studentId, subjectId, semester);
        }

        public Task UpdateSubjectSummary(SubjectSummariesModel subjectSummary)
        {
            return _subjectSummariesRepository.UpdateSubjectSummary(subjectSummary);
        }

        public Task<SubjectSummariesModel> CreateSubjectSummary(SubjectSummariesModel subjectSummary)
        {
            return _subjectSummariesRepository.CreateSubjectSummary(subjectSummary);
        }

        public Task<bool> SubjectSummaryExists(int id)
        {
            return _subjectSummariesRepository.SubjectSummaryExists(id);
        }

        public Task DeleteSubjectSummary(int id)
        {
            return _subjectSummariesRepository.DeleteSubjectSummary(id);
        }
    }
}
