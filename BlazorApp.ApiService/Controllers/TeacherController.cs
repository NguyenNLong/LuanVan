using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherService teacherService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetTeachers()
        {
            var teachers = await teacherService.GetTeachers();
            return Ok(new BaseResponseModel { Success = true, Data = teachers });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateTeacher(TeachersModel teacherModel)
        {
            var createdTeacher = await teacherService.CreateTeacher(teacherModel);
            return Ok(new BaseResponseModel { Success = true, Data = createdTeacher });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetTeacher(int id)
        {
            var teacherModel = await teacherService.GetTeacher(id);

            if (teacherModel == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = teacherModel });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeachersModel teacherModel)
        {
            if (id != teacherModel.ID || !await teacherService.TeacherExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await teacherService.UpdateTeacher(teacherModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            if (!await teacherService.TeacherExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
            }
            await teacherService.DeleteTeacher(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
