using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Repositories
{
    public interface ISchoolYearRepository
    {
        Task<List<SchoolYearModel>> GetYears();
        Task<SchoolYearModel> CreateSchoolYear(SchoolYearModel schoolYearModel);
    }
    public class SchoolYearRepository(AppDbContext dbContext) : ISchoolYearRepository
    {
		public async Task<SchoolYearModel> CreateSchoolYear(SchoolYearModel schoolYearModel)
		{
			dbContext.SchoolYears.Add(schoolYearModel);
			await dbContext.SaveChangesAsync();
			return schoolYearModel;
		}

		public Task<List<SchoolYearModel>> GetYears()
        {
            return dbContext.SchoolYears.ToListAsync();
        }
    }

}
