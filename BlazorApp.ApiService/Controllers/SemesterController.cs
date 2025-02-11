using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController(ISemesterService semesterService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetSemester()
        {
            var semester = await semesterService.GetSemester();
            return Ok(new BaseResponseModel { Success = true, Data = semester });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateSemester(SemestersModel semesterModel)
        {
            var createSemester = await semesterService.CreateSemester(semesterModel);
            return Ok(new BaseResponseModel { Success = true, Data = createSemester });
        }

        [HttpGet("by-year/{YearId}")]
        public async Task<ActionResult<BaseResponseModel>> GetSemestersByYearId(int YearId)
        {
            var semesters = await semesterService.GetSemestersByYearId(YearId);
            return Ok(new BaseResponseModel
            {
                Success = true,
                Data = semesters
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetSemesterById(int id)
        {
            var semesterModel = await semesterService.GetSemesterById(id);

            if (semesterModel == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy lớp học" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = semesterModel });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemeter(int id, SemestersModel semesterModel)
        {
            if (id != semesterModel.ID || !await semesterService.SemeterExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await semesterService.UpdateSemeter(semesterModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemeter(int id)
        {
            if (!await semesterService.SemeterExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
            }
            await semesterService.DeleteSemeter(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
