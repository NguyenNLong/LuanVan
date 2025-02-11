using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingAssignmentsController : ControllerBase
    {
        private readonly ITeachingAssignmentService _service;

        public TeachingAssignmentsController(ITeachingAssignmentService service)
        {
            _service = service;
        }

        // Lấy danh sách tất cả phân công
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetAllAssignments()
        {
            var assignments = await _service.GetAllAssignments();
            return Ok(new BaseResponseModel { Success = true, Data = assignments });
        }

        // Lấy phân công theo năm học
        [HttpGet("by-schoolyear/{schoolYearId}")]
        public async Task<ActionResult<BaseResponseModel>> GetAssignmentsByYear(int schoolYearId)
        {
            var assignments = await _service.GetAssignmentsByYear(schoolYearId);
            return Ok(new BaseResponseModel { Success = true, Data = assignments });
        }

        // Lấy phân công theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetAssignmentById(int id)
        {
            var assignment = await _service.GetAssignmentById(id);
            if (assignment == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Phân công không tồn tại" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = assignment });
        }

        // Thêm phân công
        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> AddAssignment(TeachingAssignmentModel assignment)
        {
            var addedAssignment = await _service.AddAssignment(assignment);
            return Ok(new BaseResponseModel { Success = true, Data = addedAssignment });
        }

        // Cập nhật phân công
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, TeachingAssignmentModel assignment)
        {
            if (id != assignment.ID || !await _service.AssignmentExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }
            await _service.UpdateAssignment(assignment);
            return Ok(new BaseResponseModel { Success = true });
        }

        // Xóa phân công
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            if (!await _service.AssignmentExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Phân công không tồn tại" });
            }
            await _service.DeleteAssignment(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
