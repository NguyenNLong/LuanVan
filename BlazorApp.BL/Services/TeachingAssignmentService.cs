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
        Task<List<TeachingAssignmentModel>> GetAllAssignments();
        Task<List<TeachingAssignmentModel>> GetAssignmentsByYear(int schoolYearId);
        Task<TeachingAssignmentModel> GetAssignmentById(int id);
        Task<TeachingAssignmentModel> AddAssignment(TeachingAssignmentModel assignment);
        Task UpdateAssignment(TeachingAssignmentModel assignment);
        Task DeleteAssignment(int id);
        Task<bool> AssignmentExists(int id);
    }
    public class TeachingAssignmentService(ITeachingAssignmentRepository teachingAssignmentRepository) : ITeachingAssignmentService
    {

        public Task<List<TeachingAssignmentModel>> GetAllAssignments()
        {
            return teachingAssignmentRepository.GetAllAssignments();
        }

        public Task<List<TeachingAssignmentModel>> GetAssignmentsByYear(int schoolYearId)
        {
            return teachingAssignmentRepository.GetAssignmentsByYear(schoolYearId);
        }

        public Task<TeachingAssignmentModel> GetAssignmentById(int id)
        {
            return teachingAssignmentRepository.GetAssignmentById(id);
        }

        public Task<TeachingAssignmentModel> AddAssignment(TeachingAssignmentModel assignment)
        {
            return teachingAssignmentRepository.AddAssignment(assignment);
        }

        public Task UpdateAssignment(TeachingAssignmentModel assignment)
        {
            return teachingAssignmentRepository.UpdateAssignment(assignment);
        }

        public Task DeleteAssignment(int id)
        {
            return teachingAssignmentRepository.DeleteAssignment(id);
        }

        public Task<bool> AssignmentExists(int id)
        {
            return teachingAssignmentRepository.AssignmentExists(id);
        }
    }

}
