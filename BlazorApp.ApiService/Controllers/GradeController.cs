using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetGrades()
        {
            var grades = await _gradeService.GetGrades();
            return Ok(new BaseResponseModel { Success = true, Data = grades });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetGrade(int id)
        {
            var grade = await _gradeService.GetGrade(id);
            if (grade == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy khối" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = grade });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateGrade(GradeModel grade)
        {
            var createdGrade = await _gradeService.CreateGrade(grade);
            return Ok(new BaseResponseModel { Success = true, Data = createdGrade });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, GradeModel grade)
        {
            if (id != grade.ID || !await _gradeService.GradeExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await _gradeService.UpdateGrade(grade);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (!await _gradeService.GradeExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy khối" });
            }

            await _gradeService.DeleteGrade(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
