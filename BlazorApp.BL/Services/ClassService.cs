using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IClassService
    {
        Task<List<ClassModel>> GetClasses();                  // Lấy danh sách Lớp
        Task<ClassModel> GetClass(int id);                   // Lấy Lớp theo ID
        Task<List<ClassModel>> GetClassesByGrade(int gradeId);
        Task UpdateClass(ClassModel classModel);           // Cập nhật Lớp
        Task<ClassModel> CreateClass(ClassModel classModel); // Tạo Lớp mới
        Task<bool> ClassExists(int id);                        // Kiểm tra Class có tồn tại không
        Task DeleteClass(int id);                              // Xóa Class
    }

    public class ClassService(IClassRepository classRepository) : IClassService
    {
        
        public Task<bool> ClassExists(int id)
        {
            return classRepository.ClassExists(id);
        }

        public Task<ClassModel> CreateClass(ClassModel classModel)
        {
            return classRepository.CreateClass(classModel);
        }

        public Task DeleteClass(int id)
        {
            return classRepository.DeleteClass(id);
        }

        public Task<ClassModel> GetClass(int id)
        {
            return classRepository.GetClass(id);
        }

        public Task<List<ClassModel>> GetClasses()
        {
            return classRepository.GetClasses();
        }

        public Task<List<ClassModel>> GetClassesByGrade(int gradeId)
        {
            return classRepository.GetClassesByGrade(gradeId);
        }

        public Task UpdateClass(ClassModel classModel)
        {
            return classRepository.UpdateClass(classModel);
        }
    }
}
