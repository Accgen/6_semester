using System.Collections.Generic;

namespace SPP.Lab2.models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string NickName { get; set; }
        public string PhoneName { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}