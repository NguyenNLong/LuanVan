using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController(IGradeService gradeService) : ControllerBase
    {


        [HttpGet("grades")]
        public async Task<ActionResult<BaseResponseModel>> GetGrades()
        {
            var grades = await gradeService.GetGrades();
            return Ok(new BaseResponseModel { Success = true, Data = grades });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetGradeById(int id)
        {
            var grade = await gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy khối" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = grade });
        }

        
    }
}
