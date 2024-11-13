using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{

    public interface ISemesterSummariesService
    {
        Task<List<SemesterSummariesModel>> GetSemesterSummaries();
        Task<SemesterSummariesModel> GetSemesterSummary(int id);
        Task<List<SemesterSummariesModel>> GetSemesterSummariesByStudent(int studentId);
        Task<SemesterSummariesModel> CreateSemesterSummary(SemesterSummariesModel summary);
        Task UpdateSemesterSummary(SemesterSummariesModel summary);
        Task<bool> SemesterSummaryExists(int id);
        Task DeleteSemesterSummary(int id);
    }

    public class SemesterSummariesService : ISemesterSummariesService
    {
        private readonly ISemesterSummariesRepository _repository;

        public SemesterSummariesService(ISemesterSummariesRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SemesterSummariesModel>> GetSemesterSummaries()
        {
            return _repository.GetSemesterSummaries();
        }

        public Task<SemesterSummariesModel> GetSemesterSummary(int id)
        {
            return _repository.GetSemesterSummary(id);
        }

        public Task<List<SemesterSummariesModel>> GetSemesterSummariesByStudent(int studentId)
        {
            return _repository.GetSemesterSummariesByStudent(studentId);
        }

        public Task<SemesterSummariesModel> CreateSemesterSummary(SemesterSummariesModel summary)
        {
            return _repository.CreateSemesterSummary(summary);
        }

        public Task UpdateSemesterSummary(SemesterSummariesModel summary)
        {
            return _repository.UpdateSemesterSummary(summary);
        }

        public Task<bool> SemesterSummaryExists(int id)
        {
            return _repository.SemesterSummaryExists(id);
        }

        public Task DeleteSemesterSummary(int id)
        {
            return _repository.DeleteSemesterSummary(id);
        }
    }
}

