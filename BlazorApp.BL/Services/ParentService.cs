﻿using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IParentService
    {
        Task<List<ParentModel>> GetParents();                        // Lấy danh sách phụ huynh
        Task<ParentModel> GetParent(int id);                          // Lấy phụ huynh theo ID
        Task<ParentModel> GetParentByUserID(int userid);              // Lấy phụ huynh theo UserID
        Task UpdateParent(ParentModel parentModel);                   // Cập nhật phụ huynh
        Task<ParentModel> CreateParent(ParentModel parentModel);     // Tạo phụ huynh mới
        Task<bool> ParentExists(int id);                               // Kiểm tra phụ huynh có tồn tại không
        Task DeleteParent(int id);                                     // Xóa phụ huynh
    }

    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;

        // Constructor nhận vào IParentRepository qua dependency injection
        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        // Phương thức tạo phụ huynh mới
        public Task<ParentModel> CreateParent(ParentModel parentModel)
        {
            return _parentRepository.CreateParent(parentModel);
        }

        // Phương thức lấy phụ huynh theo ID
        public Task<ParentModel> GetParent(int id)
        {
            return _parentRepository.GetParent(id);
        }

        // Phương thức lấy phụ huynh theo UserID
        public Task<ParentModel> GetParentByUserID(int userid)
        {
            return _parentRepository.GetParentByUserID(userid);
        }

        // Phương thức lấy danh sách tất cả phụ huynh
        public Task<List<ParentModel>> GetParents()
        {
            return _parentRepository.GetParents();
        }

        // Phương thức kiểm tra xem phụ huynh có tồn tại không
        public Task<bool> ParentExists(int id)
        {
            return _parentRepository.ParentExists(id);
        }

        // Phương thức cập nhật thông tin phụ huynh
        public Task UpdateParent(ParentModel parentModel)
        {
            return _parentRepository.UpdateParent(parentModel);
        }

        // Phương thức xóa phụ huynh
        public Task DeleteParent(int id)
        {
            return _parentRepository.DeleteParent(id);
        }
    }
}
