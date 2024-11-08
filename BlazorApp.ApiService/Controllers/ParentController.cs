using BlazorApp.BL.Services;
using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController(IParentService parentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetParents()
        {
            var parents = await parentService.GetParents();
            return Ok(new BaseResponseModel { Success = true, Data = parents });
        }

        [HttpPost]
        public async Task<ActionResult<ParentModel>> CreateProduct(ParentModel parentModel)
        {
            await parentService.CreateParent(parentModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetParrent(int id)
        {
            var parentModel = await parentService.GetParent(id);

            if (parentModel == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = parentModel });
        }

		[HttpGet("getbyuserid/{userid}")]
		public async Task<ActionResult<BaseResponseModel>> GetParentByUserID(int userid)
		{
			var parentModel = await parentService.GetParentByUserID(userid);

			if (parentModel == null)
			{
				return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Không tìm thấy giáo viên" });
			}
			return Ok(new BaseResponseModel { Success = true, Data = parentModel });
		}

		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateParent(int id, ParentModel parentModel)
        {
            if (id != parentModel.ID || !await parentService.ParentExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad request" });
            }

            await parentService.UpdateParent(parentModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            if (!await parentService.ParentExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            await parentService.DeleteParent(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
