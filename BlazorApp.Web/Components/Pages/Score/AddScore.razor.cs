using BlazorApp.Model.Entities;
using BlazorApp.Model.Models.Others;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorApp.Web.Components.Pages.Score
{
	public partial class AddScore
	{
		public List<SubjectModel> Subjects { get; set; } = new();
		public List<ClassModel> Classes { get; set; } = new();
		public List<StudentsModel> Students { get; set; } = new();
		public List<SchoolYearModel> Years = new();
		public List<SemestersModel> Semesters { get; set; }

		public ScoresModel Scores { get; set; }

		[Inject]
		private ApiClient ApiClient { get; set; }
		[Inject]
		private IToastService ToastService { get; set; }
		[Inject]
		private NavigationManager NavigationManager { get; set; }
		private int SelectedSubjectId;
		private int SelectedClassId;
		private int SelectedSemesterId;
		private int SelectedYearId;

		protected override async Task OnInitializedAsync()

		{
			var yearRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/SchoolYear");
			if (yearRes != null && yearRes.Success)
			{
				Years = JsonConvert.DeserializeObject<List<SchoolYearModel>>(yearRes.Data.ToString());
			}
			var subjectsRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Subject");

			if (subjectsRes != null && subjectsRes.Success)
			{

				Subjects = JsonConvert.DeserializeObject<List<SubjectModel>>(subjectsRes.Data.ToString());
			}
			var classRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Class");

			if (classRes != null && classRes.Success)
			{

				Classes = JsonConvert.DeserializeObject<List<ClassModel>>(classRes.Data.ToString());
			}
		}



		private async Task OnSubjectChange(ChangeEventArgs e)

		{

			if (int.TryParse(e.Value.ToString(), out int subjectId))

			{

				SelectedSubjectId = subjectId;

			}

			await LoadStudents();

		}



		private async Task OnClassChange(ChangeEventArgs e)

		{

			if (int.TryParse(e.Value.ToString(), out int classId))

			{

				SelectedClassId = classId;

			}

			await LoadStudents();

		}



		private async Task LoadStudents()

		{

			if (SelectedSubjectId > 0 && SelectedClassId > 0)

			{
				var studentRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Student");
				if (studentRes != null && studentRes.Success)
				{

					Students = JsonConvert.DeserializeObject<List<StudentsModel>>(studentRes.Data.ToString());
				}

			}

		}

		protected async Task OnYearChanged(ChangeEventArgs e)
		{
			if (int.TryParse(e.Value.ToString(), out int yearId))
			{
				SelectedYearId = yearId;

				// Gọi API để lấy danh sách học kỳ theo năm học
				var semesterRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"api/semester/by-year/{SelectedYearId}");
				if (semesterRes != null && semesterRes.Success)
				{
					Semesters = JsonConvert.DeserializeObject<List<SemestersModel>>(semesterRes.Data.ToString());
				}
				else
				{
					Semesters = new List<SemestersModel>(); // Đảm bảo Semesters không null
					Console.WriteLine("Không thể tải danh sách học kỳ theo năm học.");
				}
			}
		}


		private async Task SaveScores()

		{

			foreach (var student in Students)

			{

				var score = new ScoresModel

				{

					StudentID = student.ID,

					ClassID = SelectedClassId,

					SubjectID = SelectedSubjectId,
					SemesterID = SelectedSemesterId,

					OralExam = student.Scores.OralExam,

					FifteenMinExam = student.Scores.FifteenMinExam,

					OnePeriodExam = student.Scores.OnePeriodExam,

					MidtermExam = student.Scores.MidtermExam,

					FinalExam = student.Scores.FinalExam,

					

				};



				var res = await ApiClient.PostAsync<BaseResponseModel, ScoresModel>("/api/Score/addscore", score);
				if (res != null && res.Success)
				{
					ToastService.ShowSuccess("Nhập điểm thành công!");
					NavigationManager.NavigateTo("/Score");
				}

			}



			// Thông báo lưu thành công

			Console.WriteLine("Điểm đã được lưu thành công.");

		}
	}
}

