using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ISubjectSummaryService
    {
        Task<List<SubjectSummaryModel>> GetSubjectSummaries(int studentId, int semesterId);
        Task<SubjectSummaryModel> GetById(int id);
        Task Create(SubjectSummaryModel subjectSummary);
        Task Update(SubjectSummaryModel subjectSummary);
        Task Delete(int id);
    }

    public class SubjectSummaryService(ISubjectSummaryRepository subjectSummaryRepository) : ISubjectSummaryService
    {
        

        public async Task<List<SubjectSummaryModel>> GetSubjectSummaries(int studentId, int semesterId)
        {
            return await subjectSummaryRepository.GetSubjectSummaries(studentId, semesterId);
        }

        public async Task<SubjectSummaryModel> GetById(int id)
        {
            return await subjectSummaryRepository.GetById(id);
        }

        public async Task Create(SubjectSummaryModel subjectSummary)
        {
            await subjectSummaryRepository.Create(subjectSummary);
        }

        public async Task Update(SubjectSummaryModel subjectSummary)
        {
            await subjectSummaryRepository.Update(subjectSummary);
        }

        public async Task Delete(int id)
        {
            await subjectSummaryRepository.Delete(id);
        }
    }

}
