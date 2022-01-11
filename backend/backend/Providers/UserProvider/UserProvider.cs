using backend.Models;
using backend.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly DatabaseContext _dbContext;

        public UserProvider(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var res = await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return res.Entity;
        }


        public async Task<User> DeleteUserAsync(Guid userId)
        {
            User dbUser = await _dbContext.Users.FindAsync(userId);
            var res = _dbContext.Remove(dbUser);
            await _dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteUsersAsync()
        {
            _dbContext.Users.RemoveRange(_dbContext.Users.ToArray());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            User dbUser = await _dbContext.Users.FindAsync(userId);
            return dbUser;
        }

        public List<User> GetUsersAsync()
        {
            List<User> dbUsers = _dbContext.Users.ToList();
            return dbUsers;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
