/*using BlazorApp.BL.Repositories;
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
        Task<List<SchoolYearModel>> GetTeachingAssignments();                      // Lấy danh sách phân công giảng dạy
        Task<SchoolYearModel> GetTeachingAssignment(int id);                       // Lấy phân công theo ID
        Task UpdateTeachingAssignment(SchoolYearModel assignment);                 // Cập nhật phân công giảng dạy
        Task<SchoolYearModel> CreateTeachingAssignment(SchoolYearModel assignment); // Tạo mới phân công giảng dạy
        Task<bool> TeachingAssignmentExists(int id);                                       // Kiểm tra phân công có tồn tại không
        Task DeleteTeachingAssignment(int id);                                             // Xóa phân công giảng dạy
    }

    public class TeachingAssignmentService(ITeachingAssignmentRepository teachingAssignmentRepository) : ITeachingAssignmentService
    {
        
        public Task<List<SchoolYearModel>> GetTeachingAssignments()
        {
            return teachingAssignmentRepository.GetTeachingAssignments();
        }

        public Task<SchoolYearModel> GetTeachingAssignment(int id)
        {
            return teachingAssignmentRepository.GetTeachingAssignment(id);
        }

        public Task UpdateTeachingAssignment(SchoolYearModel assignment)
        {
            return teachingAssignmentRepository.UpdateTeachingAssignment(assignment);
        }

        public Task<SchoolYearModel> CreateTeachingAssignment(SchoolYearModel assignment)
        {
            return teachingAssignmentRepository.CreateTeachingAssignment(assignment);
        }

        public Task<bool> TeachingAssignmentExists(int id)
        {
            return teachingAssignmentRepository.TeachingAssignmentExists(id);
        }

        public Task DeleteTeachingAssignment(int id)
        {
            return teachingAssignmentRepository.DeleteTeachingAssignment(id);
        }
    }
}
*/