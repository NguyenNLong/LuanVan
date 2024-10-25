using BlazorApp.Database.Data;
using BlazorApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Model.Models;

namespace BlazorApp.BL.Repositories
{
    public interface IAuthRepository
    {
        Task<UserModel> GetUserByLogin(string username, string password);
        Task RemoveRefreshTokenByUserID(int userID);
        Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);
        Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);
        Task<UserModel> CreateUser(string username, string password, List<int> roleIds);
    }
    public class AuthRepository(AppDbContext dbContext) : IAuthRepository
    {
        public async Task<UserModel> GetUserByLogin(string username, string password)
        {
            var user = await dbContext.Users.Include(n => n.UserRoles)
                                   .ThenInclude(n => n.Role)
                                   .FirstOrDefaultAsync(n => n.Username == username);

            // Nếu user tồn tại và mật khẩu khớp với mật khẩu đã được hash
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user; // Trả về user nếu mật khẩu đúng
            }

            return null;

        }
        public async Task RemoveRefreshTokenByUserID(int userID)
        {
            var refreshToken = dbContext.RefreshTokens.FirstOrDefault(n => n.UserID == userID);
            if (refreshToken != null)
            {
                dbContext.RemoveRange(refreshToken);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
        {
            await dbContext.RefreshTokens.AddAsync(refreshTokenModel);
            await dbContext.SaveChangesAsync();
        }

        public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
        {
            return dbContext.RefreshTokens.Include(n => n.User).ThenInclude(n => n.UserRoles).ThenInclude(n => n.Role).FirstOrDefaultAsync(n => n.RefreshToken == refreshToken);
        }
        public async Task<UserModel> CreateUser(string username, string password, List<int> roleIds)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser == null)
            {
                
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                var newUser = new UserModel
                {
                    Username = username,
                    Password = hashedPassword,
                    UserRoles = new List<UserRoleModel>()
                };

                foreach (var roleId in roleIds)
                {
                    var role = await dbContext.Roles.FindAsync(roleId);
                    if (role != null)
                    {
                        newUser.UserRoles.Add(new UserRoleModel
                        {
                            RoleID = roleId,
                            Role = role
                        });
                    }
                }

                dbContext.Users.Add(newUser);
                await dbContext.SaveChangesAsync();

                return newUser;
            }
            else { return null; }
        }
    }
}
