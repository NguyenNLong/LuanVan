using BlazorApp.BL.Repositories;
using BlazorApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.BL.Services
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetRoles();
    }
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        public Task<List<RoleModel>> GetRoles()
        {
            return roleRepository.GetRoles();
        }
    }
}
