using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using BlazorApp.Web.Components.BaseComponents;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorApp.Web.Components.Pages.Teacher
{
    public partial class IndexTeacher
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<TeachersModel> TeacherModels { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteID { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadTeacher();
        }
        protected async Task LoadTeacher()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Teacher");
            if (res != null && res.Success)
            {
                TeacherModels = JsonConvert.DeserializeObject<List<TeachersModel>>(res.Data.ToString());
            }
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Teacher/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete Teacher successfully");
                await LoadTeacher();
                Modal.Close();
            }
        }
    }
}
