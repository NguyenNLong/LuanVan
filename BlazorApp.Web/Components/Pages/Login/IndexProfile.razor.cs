using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlazorApp.Web.Components.Pages.Login
{
    public partial class IndexProfile
    {
        public List<ClassModel> Classes { get; set; }

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
                var teacherRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Teacher/getbyuserid/{User.ID}");
                if (teacherRes != null && teacherRes.Success)
                {
                    Teacher = JsonConvert.DeserializeObject<TeachersModel>(teacherRes.Data.ToString());
                }
            }
            else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
            {

                var studentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Student/getbyuserid/{User.ID}");
                if (studentRes != null && studentRes.Success)
                {
                    Student = JsonConvert.DeserializeObject<StudentsModel>(studentRes.Data.ToString());
                }
            }
            else if (User.UserRoles.Any(ur => ur.Role.RoleName == "Parent"))
            {
                var parentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Parent/getbyuserid/{User.ID}");
                if (parentRes != null && parentRes.Success)
                {
                    Parent = JsonConvert.DeserializeObject<ParentModel>(parentRes.Data.ToString());
                }
            }

            var classRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Class");
            if (classRes != null && classRes.Success)
            {
                Classes = JsonConvert.DeserializeObject<List<ClassModel>>(classRes.Data.ToString());
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
                User.ID = int.Parse(userClaims.FindFirst("UserId")?.Value);
            }
            else
            {
                ToastService.ShowError("Không thể lấy thông tin người dùng.");
            }
        }


        }
    }

