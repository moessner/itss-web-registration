using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Providers.GroupProvider
{
    public class GroupProvider : IGroupProvider
    {
        private readonly DatabaseContext _dbContext;

        public GroupProvider(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Group> GetGroupAsync(string groupName, string authorizationCode)
        {

            var group =  await _dbContext.Group.Where(s => s.Name == groupName && s.AuthorizationCode == authorizationCode)
                .FirstOrDefaultAsync();
            return group;
            
        }

        public List<Group> GetGroupsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}