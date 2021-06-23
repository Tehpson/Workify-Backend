using System.Collections.Generic;

namespace Workify_Backend.Models
{
    public class User
    {
        public ulong Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PublicProfile { get; set; }
        public string Bio { get; set; }
        public List<UserTraining> Trainings { get; set; }
    }
}