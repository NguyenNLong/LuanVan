using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using BlazorApp.Web.Components.BaseComponents;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorApp.Web.Components.Pages.Student
{
    public partial class IndexStudent
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<StudentsModel> StudentsModel { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteID { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadStudent();
        }
        protected async Task LoadStudent()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Student");
            if (res != null && res.Success)
            {
                StudentsModel = JsonConvert.DeserializeObject<List<StudentsModel>>(res.Data.ToString());
            }
        }
        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Student/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Xóa học sinh thành công");
                await LoadStudent();
                Modal.Close();
            }
        }
    }
}
