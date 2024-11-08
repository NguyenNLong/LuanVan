using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Data;

namespace BlazorApp.Web.Components.Pages.Login
{
	public partial class UpdateInfo
	{
		public TeachersModel Teacher { get; set; } = new();

		public StudentsModel Student { get; set; } = new();

		public ParentModel Parent { get; set; } = new();
		public UserModel User { get; set; } = new UserModel();
		[Inject]
		public AuthenticationStateProvider AuthStateProvider { get; set; }

		[Inject]
		private IToastService ToastService { get; set; }
		[Inject]
		private NavigationManager NavigationManager { get; set; }
		[Inject]
		private ApiClient ApiClient { get; set; }
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			await LoadUserFromToken();

			if (User.UserRoles.Any(ur => ur.Role.RoleName == "Teacher"))
			{
				Teacher = new TeachersModel();
				var teacherRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Teacher/getbyuserid/{User.ID}");
				if (teacherRes != null && teacherRes.Success)
				{
					Teacher = JsonConvert.DeserializeObject<TeachersModel>(teacherRes.Data.ToString());
				}
				else if (teacherRes == null && !teacherRes.Success)
				{
					// Nếu không tìm thấy học sinh, trả về Student rỗng
					Teacher = new TeachersModel();
				}

			}
			else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
			{
				Student = new StudentsModel();
				var studentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Student/getbyuserid/{User.ID}");
				if (studentRes != null && studentRes.Success)
				{
					Student = JsonConvert.DeserializeObject<StudentsModel>(studentRes.Data.ToString());
				}
				else if (studentRes == null && !studentRes.Success)
				{
					// Nếu không tìm thấy học sinh, trả về Student rỗng
					Student = new StudentsModel();
				}
			}
			else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Parent"))
			{
				Parent = new ParentModel();
				var parentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Parent/getbyuserid/{User.ID}");
				if (parentRes != null && parentRes.Success)
				{
					Parent = JsonConvert.DeserializeObject<ParentModel>(parentRes.Data.ToString());
				}
				else if (parentRes == null && !parentRes.Success)
				{
					// Nếu không tìm thấy học sinh, trả về Student rỗng
					Parent = new ParentModel();
				}
			}


		}
		protected async Task LoadUserFromToken()
		{
			var authState = await AuthStateProvider.GetAuthenticationStateAsync();
			var userClaims = authState.User;

			if (userClaims.Identity.IsAuthenticated)
			{
				User.Username = userClaims.FindFirst(ClaimTypes.Name)?.Value;
				var roles = userClaims.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
				User.UserRoles = roles.Select(roleName => new UserRoleModel
				{
					Role = new RoleModel { RoleName = roleName }
				}).ToList();
				// Nếu bạn có thêm các thông tin khác như ID, email, role, thì trích xuất từ claims:
				User.ID = int.Parse(userClaims.FindFirst("UserId")?.Value); // Giả sử bạn lưu UserId trong claim
			}
			else
			{
				ToastService.ShowError("Không thể lấy thông tin người dùng.");
			}
		}
		public async Task Submit()
		{
			if (User.UserRoles.Any(ur => ur.Role.RoleName == "Teacher"))
			{
				var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Teacher/getbyuserid/{User.ID}");
				if (res == null && !res.Success)
				{
					var TeacherRes = await ApiClient.PostAsync<BaseResponseModel, TeachersModel>($"/api/Teacher/getbyuserid/{User.ID}", Teacher);
					if (TeacherRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}
				else if (res != null && res.Success)
				{
					var TeacherRes = await ApiClient.PutAsync<BaseResponseModel, TeachersModel>($"/api/Teacher/getbyuserid/{User.ID}", Teacher);
					if (TeacherRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}

			}
			else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
			{
				var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Student/getbyuserid/{User.ID}");
				if (res == null && !res.Success)
				{
					var StudentRes = await ApiClient.PostAsync<BaseResponseModel, StudentsModel>($"/api/Student/getbyuserid/{User.ID}", Student);
					if (StudentRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}
				else if (res != null && res.Success)
				{
					var StudentRes = await ApiClient.PutAsync<BaseResponseModel, StudentsModel>($"/api/Student/getbyuserid/{User.ID}", Student);
					if (StudentRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}
				// Load existing student data if necessary
			}
			else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Parent"))
			{
				var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Parent/getbyuserid/{User.ID}");
				if (res == null && !res.Success)
				{
					var ParentRes = await ApiClient.PostAsync<BaseResponseModel, ParentModel>($"/api/Parent/getbyuserid/{User.ID}", Parent);
					if (ParentRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}
				else if (res != null && res.Success)
				{
					var ParentRes = await ApiClient.PutAsync<BaseResponseModel, ParentModel>($"/api/Parent/getbyuserid/{User.ID}", Parent);
					if (ParentRes != null && res.Success)
					{
						ToastService.ShowSuccess("Cập nhật thông tin thành công!");
						NavigationManager.NavigateTo("/");
					}
				}
				// Load existing parent data if necessary
			}

		}
	}
}
