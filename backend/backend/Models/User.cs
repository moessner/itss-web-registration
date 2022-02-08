using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Base64Image { get; set; }
        public string ImagePath { get; set; }
        
        public int GroupId { get; set; }
        
        public Group Group { get; set; }
    }

    public class Group
    {
        public int GroupId { get; set; }
        
        public List<User> Users { get; set; }

        public string Name { get; set; }

        public string AuthorizationCode { get; set; }
    }
}
