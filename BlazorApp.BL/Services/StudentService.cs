using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IStudentService
    {
        Task<List<StudentsModel>> GetStudents();                // Lấy danh sách học sinh
        Task<StudentsModel> GetStudent(int id);                 // Lấy học sinh theo ID
		Task<StudentsModel> GetStudentByUserID(int userid);

		Task UpdateStudent(StudentsModel studentModel);         // Cập nhật thông tin học sinh
        Task<StudentsModel> CreateStudent(StudentsModel studentModel); // Tạo học sinh mới
        Task<bool> StudentExists(int id);                       // Kiểm tra học sinh có tồn tại không
        Task DeleteStudent(int id);                             // Xóa học sinh
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        // Constructor nhận vào IStudentRepository qua dependency injection
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Phương thức tạo học sinh mới
        public Task<StudentsModel> CreateStudent(StudentsModel studentModel)
        {
            return _studentRepository.CreateStudent(studentModel);
        }

        // Phương thức lấy học sinh theo ID
        public Task<StudentsModel> GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }

		public Task<StudentsModel> GetStudentByUserID(int userid)
		{
			return _studentRepository.GetStudentByUserID(userid);
		}

		// Phương thức lấy danh sách tất cả học sinh
		public Task<List<StudentsModel>> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        // Phương thức kiểm tra xem học sinh có tồn tại không
        public Task<bool> StudentExists(int id)
        {
            return _studentRepository.StudentExists(id);
        }

        // Phương thức cập nhật thông tin học sinh
        public Task UpdateStudent(StudentsModel studentModel)
        {
            return _studentRepository.UpdateStudent(studentModel);
        }

        // Phương thức xóa học sinh
        public Task DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }
    }
}
