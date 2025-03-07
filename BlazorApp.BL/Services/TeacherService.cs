﻿using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{

    public interface ITeacherService
    {
        Task<List<TeachersModel>> GetTeachers();                  // Lấy danh sách giáo viên
        Task<TeachersModel> GetTeacher(int id);                   // Lấy giáo viên theo ID
        Task<TeachersModel> GetTeacherByUserID(int userid);
        Task UpdateTeacher(TeachersModel teacherModel);           // Cập nhật giáo viên
        Task<TeachersModel> CreateTeacher(TeachersModel teacherModel); // Tạo giáo viên mới
        Task<bool> TeacherExists(int id);                        // Kiểm tra giáo viên có tồn tại không
        Task DeleteTeacher(int id);                              // Xóa giáo viên
    }

    public class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
    {
        

        // Phương thức tạo giáo viên mới
        public Task<TeachersModel> CreateTeacher(TeachersModel teacherModel)
        {
            return teacherRepository.CreateTeacher(teacherModel);
        }

        // Phương thức lấy giáo viên theo ID
        public Task<TeachersModel> GetTeacher(int id)
        {
            return teacherRepository.GetTeacher(id);
        }

        // Phương thức lấy giáo viên theo UserID
        public Task<TeachersModel> GetTeacherByUserID(int userid)
        {
            return teacherRepository.GetTeacherByUserID(userid);
        }

        // Phương thức lấy danh sách tất cả giáo viên
        public Task<List<TeachersModel>> GetTeachers()
        {
            return teacherRepository.GetTeachers();
        }

        // Phương thức kiểm tra xem giáo viên có tồn tại không
        public Task<bool> TeacherExists(int id)
        {
            return teacherRepository.TeacherExists(id);
        }

        // Phương thức cập nhật thông tin giáo viên
        public Task UpdateTeacher(TeachersModel teacherModel)
        {
            return teacherRepository.UpdateTeacher(teacherModel);
        }

        // Phương thức xóa giáo viên
        public Task DeleteTeacher(int id)
        {
            return teacherRepository.DeleteTeacher(id);
        }

    }
}
