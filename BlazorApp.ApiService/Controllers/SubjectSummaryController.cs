using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectSummaryController(ISubjectSummaryService subjectSummaryService) : ControllerBase
    {

        [HttpGet("student/{studentId}/semester/{semesterId}")]
        public async Task<ActionResult<BaseResponseModel>> GetSubjectSummaries(int studentId, int semesterId)
        {
            var summaries = await subjectSummaryService.GetSubjectSummaries(studentId, semesterId);
            return Ok(new BaseResponseModel { Success = true, Data = summaries });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetById(int id)
        {
            var summary = await subjectSummaryService.GetById(id);
            if (summary == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy dữ liệu" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = summary });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> Create([FromBody] SubjectSummaryModel model)
        {
            await subjectSummaryService.Create(model);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseModel>> Update(int id, [FromBody] SubjectSummaryModel model)
        {
            if (id != model.ID)
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }
            await subjectSummaryService.Update(model);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponseModel>> Delete(int id)
        {
            await subjectSummaryService.Delete(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }

}
