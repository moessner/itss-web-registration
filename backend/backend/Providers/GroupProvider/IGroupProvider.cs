using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;


namespace backend.Providers.GroupProvider
{
    public interface IGroupProvider {

            //public Task<Group> CreateGroupAsync(Group group);
            //public Task<Group> DeleteGroupAsync(int groupId);
            //public Task DeleteGroupsAsync();
            public Task<Group> GetGroupAsync(string groupName, string authenticationCode);
            public List<Group> GetGroupsAsync();
            //public Task<Group> UpdateGroupAsync(Group group);
    }
}