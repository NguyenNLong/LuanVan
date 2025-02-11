using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface ISchoolYearService
    {
        Task<List<SchoolYearModel>> GetYears();                  // Lấy danh sách Grade
		Task<SchoolYearModel> CreateSchoolYear(SchoolYearModel schoolYearModel);


	}
	public class SchoolYearService(ISchoolYearRepository schoolYearRepository) : ISchoolYearService
    {
		public Task<SchoolYearModel> CreateSchoolYear(SchoolYearModel schoolYearModel)
		{
			return schoolYearRepository.CreateSchoolYear(schoolYearModel);

		}

		public Task<List<SchoolYearModel>> GetYears()
        {
            return schoolYearRepository.GetYears();
        }
    }
}
