/*using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingAssignmentController : ControllerBase
    {
        private readonly ITeachingAssignmentService _teachingAssignmentService;

        public TeachingAssignmentController(ITeachingAssignmentService teachingAssignmentService)
        {
            _teachingAssignmentService = teachingAssignmentService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetTeachingAssignments()
        {
            var assignments = await _teachingAssignmentService.GetTeachingAssignments();
            return Ok(new BaseResponseModel { Success = true, Data = assignments });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetTeachingAssignment(int id)
        {
            var assignment = await _teachingAssignmentService.GetTeachingAssignment(id);
            if (assignment == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy phân công giảng dạy" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = assignment });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateTeachingAssignment(SchoolYearModel assignment)
        {
            var createdAssignment = await _teachingAssignmentService.CreateTeachingAssignment(assignment);
            return Ok(new BaseResponseModel { Success = true, Data = createdAssignment });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeachingAssignment(int id, SchoolYearModel assignment)
        {
            if (id != assignment.ID || !await _teachingAssignmentService.TeachingAssignmentExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await _teachingAssignmentService.UpdateTeachingAssignment(assignment);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachingAssignment(int id)
        {
            if (!await _teachingAssignmentService.TeachingAssignmentExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy phân công giảng dạy" });
            }

            await _teachingAssignmentService.DeleteTeachingAssignment(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
*/