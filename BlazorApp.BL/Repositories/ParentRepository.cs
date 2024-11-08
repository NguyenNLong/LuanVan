using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Repositories
{
    public interface IParentRepository
    {
        Task<List<ParentModel>> GetParents();                  // Lấy danh sách phụ huynh
        Task<ParentModel> GetParent(int id);                    // Lấy phụ huynh theo ID
        Task<ParentModel> GetParentByUserID(int userid);       // Lấy phụ huynh theo UserID
        Task UpdateParent(ParentModel parentModel);            // Cập nhật phụ huynh
        Task<ParentModel> CreateParent(ParentModel parentModel); // Tạo phụ huynh mới
        Task<bool> ParentExists(int id);                         // Kiểm tra phụ huynh có tồn tại không
        Task DeleteParent(int id);                               // Xóa phụ huynh
    }

    public class ParentRepository : IParentRepository
    {
        private readonly AppDbContext dbContext;

        // Constructor nhận vào AppDbContext qua dependency injection
        public ParentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Phương thức lấy danh sách phụ huynh
        public Task<List<ParentModel>> GetParents()
        {
            return dbContext.Parents.ToListAsync();
        }

        // Phương thức lấy phụ huynh theo ID
        public Task<ParentModel> GetParent(int id)
        {
            return dbContext.Parents.FirstOrDefaultAsync(p => p.ID == id);
        }

        // Phương thức lấy phụ huynh theo UserID
        public Task<ParentModel> GetParentByUserID(int userid)
        {
            return dbContext.Parents.FirstOrDefaultAsync(p => p.UserID == userid);
        }

        // Phương thức tạo mới phụ huynh
        public async Task<ParentModel> CreateParent(ParentModel parentModel)
        {
            dbContext.Parents.Add(parentModel);
            await dbContext.SaveChangesAsync();
            return parentModel;
        }

        // Phương thức cập nhật phụ huynh
        public async Task UpdateParent(ParentModel parentModel)
        {
            dbContext.Entry(parentModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        // Phương thức kiểm tra xem phụ huynh có tồn tại không
        public Task<bool> ParentExists(int id)
        {
            return dbContext.Parents.AnyAsync(p => p.ID == id);
        }

        // Phương thức xóa phụ huynh
        public async Task DeleteParent(int id)
        {
            var parent = await dbContext.Parents.FirstOrDefaultAsync(p => p.ID == id);
            if (parent != null)
            {
                dbContext.Parents.Remove(parent);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
