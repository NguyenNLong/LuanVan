using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterSummariesController : ControllerBase
    {
        private readonly ISemesterSummariesService _service;

        public SemesterSummariesController(ISemesterSummariesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetSemesterSummaries()
        {
            var summaries = await _service.GetSemesterSummaries();
            return Ok(new BaseResponseModel { Success = true, Data = summaries });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetSemesterSummary(int id)
        {
            var summary = await _service.GetSemesterSummary(id);

            if (summary == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy tổng kết học kỳ" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = summary });
        }

        [HttpGet("bystudent/{studentId}")]
        public async Task<ActionResult<BaseResponseModel>> GetSemesterSummariesByStudent(int studentId)
        {
            var summaries = await _service.GetSemesterSummariesByStudent(studentId);
            return Ok(new BaseResponseModel { Success = true, Data = summaries });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateSemesterSummary(SemesterSummariesModel summary)
        {
            var createdSummary = await _service.CreateSemesterSummary(summary);
            return Ok(new BaseResponseModel { Success = true, Data = createdSummary });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemesterSummary(int id, SemesterSummariesModel summary)
        {
            if (id != summary.ID || !await _service.SemesterSummaryExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await _service.UpdateSemesterSummary(summary);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemesterSummary(int id)
        {
            if (!await _service.SemesterSummaryExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy tổng kết học kỳ" });
            }

            await _service.DeleteSemesterSummary(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
