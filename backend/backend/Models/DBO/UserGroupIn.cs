namespace backend.Models
{
    public class UserGroupIn
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string AuthorizationCode { get; set; }
        public string GroupName { get; set; }

    }
}