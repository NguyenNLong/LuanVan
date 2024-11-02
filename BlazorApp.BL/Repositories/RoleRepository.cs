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
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetRoles();
    }
    public class RoleRepository(AppDbContext dbContext) : IRoleRepository
    {
        public Task<List<RoleModel>> GetRoles()
        {
            return dbContext.Roles.ToListAsync();
        }
    }
}
