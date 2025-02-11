using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolYearController(ISchoolYearService schoolYearService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetYears()
        {
            var years = await schoolYearService.GetYears();
            return Ok(new BaseResponseModel { Success = true, Data = years });
        }
		[HttpPost]
		public async Task<ActionResult<BaseResponseModel>> CreateSchoolYear(SchoolYearModel schoolYearModel)
		{
			var createSchoolYear = await schoolYearService.CreateSchoolYear(schoolYearModel);
			return Ok(new BaseResponseModel { Success = true, Data = createSchoolYear });
		}

	}
}
