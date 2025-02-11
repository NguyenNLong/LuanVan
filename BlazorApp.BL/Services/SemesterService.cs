using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ISemesterService
    {
        Task<List<SemestersModel>> GetSemester();

        Task<SemestersModel> GetSemesterById(int id);
        Task<List<SemestersModel>> GetSemestersByYearId(int YearId);
        Task UpdateSemeter(SemestersModel semesterModel);
        Task<SemestersModel> CreateSemester(SemestersModel semesterModel);
        Task<bool> SemeterExists(int id);
        Task DeleteSemeter(int id);
    }
    public class SemesterService(ISemesterRepository semesterRepository) : ISemesterService
    {
        
        public Task<SemestersModel> CreateSemester(SemestersModel semesterModel)
        {
            return semesterRepository.CreateSemester(semesterModel);
        }

        public Task DeleteSemeter(int id)
        {
            return semesterRepository.DeleteSemeter(id);
        }

        public Task<List<SemestersModel>> GetSemester()
        {
            return semesterRepository.GetSemester();
        }

        public Task<SemestersModel> GetSemesterById(int id)
        {
            return semesterRepository.GetSemesterById(id);
        }

        public Task<bool> SemeterExists(int id)
        {
            return semesterRepository.SemeterExists(id);

        }

        public Task UpdateSemeter(SemestersModel semesterModel)
        {
            return semesterRepository.UpdateSemeter(semesterModel);
        }
        public  Task<List<SemestersModel>> GetSemestersByYearId(int YearId)
        {
            return  semesterRepository.GetSemestersByYearId(YearId);
        }
    }

}

