using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Providers
{
    public interface IUserProvider
    {
        public Task<User> CreateUserAsync(User user);
        public Task<User> DeleteUserAsync(Guid userId);
        public Task DeleteUsersAsync();
        public Task<User> GetUserAsync(Guid userId);
        public List<User> GetUsersAsync();
        public Task<User> UpdateUserAsync(User user);
    }
}
