namespace Workify_Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserTraining
    {
        public ulong Id { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
        public string ImgPath { get; set; }
    }
}
