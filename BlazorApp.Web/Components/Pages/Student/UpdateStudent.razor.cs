using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using BlazorApp.Model.Models.User;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlazorApp.Web.Components.Pages.Student
{
    public partial class UpdateStudent : ComponentBase
    {

        [Parameter]
        public int ID { get; set; }
        public StudentsModel Student { get; set; } = new();
        public UserModel User { get; set; }
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var studentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Student/{ID}");
            if (studentRes != null && studentRes.Success)
            {
                Student = JsonConvert.DeserializeObject<StudentsModel>(studentRes.Data.ToString());
            }

        }
       
       
        public async Task Submit()
        {
            var res = await ApiClient.PutAsync<BaseResponseModel, StudentsModel>($"/api/Student/{ID}", Student);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Cập nhật người dùng thành công!");
                NavigationManager.NavigateTo("/student");
            }
        }
    }
}


