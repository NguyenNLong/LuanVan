using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ITeachingAssignmentService
    {
        Task<List<TeachingAssignmentModel>> GetTeachingAssignments();                      // Lấy danh sách phân công giảng dạy
        Task<TeachingAssignmentModel> GetTeachingAssignment(int id);                       // Lấy phân công theo ID
        Task UpdateTeachingAssignment(TeachingAssignmentModel assignment);                 // Cập nhật phân công giảng dạy
        Task<TeachingAssignmentModel> CreateTeachingAssignment(TeachingAssignmentModel assignment); // Tạo mới phân công giảng dạy
        Task<bool> TeachingAssignmentExists(int id);                                       // Kiểm tra phân công có tồn tại không
        Task DeleteTeachingAssignment(int id);                                             // Xóa phân công giảng dạy
    }

    public class TeachingAssignmentService : ITeachingAssignmentService
    {
        private readonly ITeachingAssignmentRepository _teachingAssignmentRepository;

        public TeachingAssignmentService(ITeachingAssignmentRepository teachingAssignmentRepository)
        {
            _teachingAssignmentRepository = teachingAssignmentRepository;
        }

        public Task<List<TeachingAssignmentModel>> GetTeachingAssignments()
        {
            return _teachingAssignmentRepository.GetTeachingAssignments();
        }

        public Task<TeachingAssignmentModel> GetTeachingAssignment(int id)
        {
            return _teachingAssignmentRepository.GetTeachingAssignment(id);
        }

        public Task UpdateTeachingAssignment(TeachingAssignmentModel assignment)
        {
            return _teachingAssignmentRepository.UpdateTeachingAssignment(assignment);
        }

        public Task<TeachingAssignmentModel> CreateTeachingAssignment(TeachingAssignmentModel assignment)
        {
            return _teachingAssignmentRepository.CreateTeachingAssignment(assignment);
        }

        public Task<bool> TeachingAssignmentExists(int id)
        {
            return _teachingAssignmentRepository.TeachingAssignmentExists(id);
        }

        public Task DeleteTeachingAssignment(int id)
        {
            return _teachingAssignmentRepository.DeleteTeachingAssignment(id);
        }
    }
}
