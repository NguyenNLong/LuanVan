using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(ISubjectService subjectService) : ControllerBase
    {
        

        // Lấy danh sách tất cả các môn học
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetSubjects()
        {
            var subjects = await subjectService.GetSubjects();
            return Ok(new BaseResponseModel { Success = true, Data = subjects });
        }

        // Tạo môn học mới
        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateSubject(SubjectModel subjectModel)
        {
            var createdSubject = await subjectService.CreateSubject(subjectModel);
            return Ok(new BaseResponseModel { Success = true, Data = createdSubject });
        }

        // Lấy môn học theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetSubject(int id)
        {
            var subjectModel = await subjectService.GetSubject(id);

            if (subjectModel == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy môn học" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = subjectModel });
        }
        // Cập nhật thông tin môn học
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectModel subjectModel)
        {
            if (id != subjectModel.ID || !await subjectService.SubjectExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await subjectService.UpdateSubject(subjectModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        // Xóa môn học
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            if (!await subjectService.SubjectExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy môn học" });
            }
            await subjectService.DeleteSubject(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
