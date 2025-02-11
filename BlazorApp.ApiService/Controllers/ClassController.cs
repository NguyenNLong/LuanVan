using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(IClassService classService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetClasses()
        {
            var classes = await classService.GetClasses();
            return Ok(new BaseResponseModel { Success = true, Data = classes });
        }
       


        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateClass(ClassModel classModel)
        {
            var createdClass = await classService.CreateClass(classModel);
            return Ok(new BaseResponseModel { Success = true, Data = createdClass });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetClass(int id)
        {
            var classModel = await classService.GetClass(id);

            if (classModel == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy lớp học" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = classModel });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassModel classModel)
        {
            if (id != classModel.ID || !await classService.ClassExists(id))
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Yêu cầu không hợp lệ" });
            }

            await classService.UpdateClass(classModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            if (!await classService.ClassExists(id))
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
            }
            await classService.DeleteClass(id);
            return Ok(new BaseResponseModel { Success = true });
        }
        [HttpGet("GetClassesByGradeId/{gradeId}")]
        public async Task<ActionResult<BaseResponseModel>> GetClassesByGradeId(int gradeId)
        {
            try
            {
                var classes = await classService.GetClassesByGrade(gradeId);
                return Ok(new BaseResponseModel { Success = true, Data = classes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponseModel { Success = false, ErrorMessage = "Đã xảy ra lỗi hệ thống" });
            }
        }
		
	}
}

