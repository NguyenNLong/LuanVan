using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectSummariesController : ControllerBase
    {
        private readonly ISubjectSummariesService _subjectSummariesService;

        public SubjectSummariesController(ISubjectSummariesService subjectSummariesService)
        {
            _subjectSummariesService = subjectSummariesService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetSubjectSummaries()
        {
            var summaries = await _subjectSummariesService.GetSubjectSummaries();
            return Ok(new BaseResponseModel { Success = true, Data = summaries });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetSubjectSummary(int id)
        {
            var summary = await _subjectSummariesService.GetSubjectSummary(id);
            if (summary == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm tổng kết môn học" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = summary });
        }

        [HttpGet("student/{studentId}/subject/{subjectId}/semester/{semester}")]
        public async Task<ActionResult<BaseResponseModel>> GetSubjectSummaryByStudentAndSubject(int studentId, int subjectId, int semester)
        {
            var summary = await _subjectSummariesService.GetSubjectSummaryByStudentAndSubject(studentId, subjectId, semester);
            if (summary == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm tổng kết cho học sinh và môn học trong học kỳ này" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = summary });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateSubjectSummary(SubjectSummariesModel subjectSummary)
        {
            var createdSummary = await _subjectSummariesService.CreateSubjectSummary(subjectSummary);
            return Ok(new BaseResponseModel { Success = true, Data = createdSummary });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectSummary(int id, SubjectSummariesModel subjectSummary)
        {
            if (id != subjectSummary.ID || !await _subjectSummariesService.SubjectSummaryExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await _subjectSummariesService.UpdateSubjectSummary(subjectSummary);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectSummary(int id)
        {
            if (!await _subjectSummariesService.SubjectSummaryExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy điểm tổng kết môn học" });
            }

            await _subjectSummariesService.DeleteSubjectSummary(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}

