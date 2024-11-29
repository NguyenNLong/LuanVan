using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ISubjectService
    {
        Task<List<SubjectModel>> GetSubjects();                  // Lấy danh sách môn học
        Task<SubjectModel> GetSubject(int id);                    // Lấy môn học theo ID
        
        Task UpdateSubject(SubjectModel subjectModel);            // Cập nhật môn học
        Task<SubjectModel> CreateSubject(SubjectModel subjectModel); // Tạo môn học mới
        Task<bool> SubjectExists(int id);                          // Kiểm tra môn học có tồn tại không
        Task DeleteSubject(int id);                                // Xóa môn học
    }

    public class SubjectService(ISubjectRepository subjectRepository) : ISubjectService
    {
     

        // Phương thức tạo môn học mới
        public Task<SubjectModel> CreateSubject(SubjectModel subjectModel)
        {
            return subjectRepository.CreateSubject(subjectModel);
        }

        // Phương thức lấy môn học theo ID
        public Task<SubjectModel> GetSubject(int id)
        {
            return subjectRepository.GetSubject(id);
        }

        // Phương thức lấy môn học theo tên
        

        // Phương thức lấy danh sách tất cả môn học
        public Task<List<SubjectModel>> GetSubjects()
        {
            return subjectRepository.GetSubjects();
        }

        // Phương thức kiểm tra xem môn học có tồn tại không
        public Task<bool> SubjectExists(int id)
        {
            return subjectRepository.SubjectExists(id);
        }

        // Phương thức cập nhật thông tin môn học
        public Task UpdateSubject(SubjectModel subjectModel)
        {
            return subjectRepository.UpdateSubject(subjectModel);
        }

        // Phương thức xóa môn học
        public Task DeleteSubject(int id)
        {
            return subjectRepository.DeleteSubject(id);
        }
    }
}
