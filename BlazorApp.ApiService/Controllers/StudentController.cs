using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetTeachers()
        {
            var teachers = await studentService.GetStudents();
            return Ok(new BaseResponseModel { Success = true, Data = teachers });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreatedStudent(StudentsModel studentModel)
        {
            var createdStudent = await studentService.CreateStudent(studentModel);
            return Ok(new BaseResponseModel { Success = true, Data = createdStudent });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetStudent(int id)
        {
            var studentModel = await studentService.GetStudent(id);

            if (studentModel == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy học sinh" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = studentModel });
        }
		[HttpGet("getbyuserid/{userid}")]
		public async Task<ActionResult<BaseResponseModel>> GetStudentByUserID(int userid)
		{
			var studentModel = await studentService.GetStudentByUserID(userid);

			if (studentModel == null)
			{
				return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
			}
			return Ok(new BaseResponseModel { Success = true, Data = studentModel });
		}

		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentsModel studentsModel)
        {
            if (id != studentsModel.ID || !await studentService.StudentExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await studentService.UpdateStudent(studentsModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (!await studentService.StudentExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy học sinh" });
            }
            await studentService.DeleteStudent(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
