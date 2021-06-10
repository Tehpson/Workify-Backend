namespace Workify_Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User
    {
        public ulong Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
