using System;

namespace SampleProject.WebApp.Areas.Member.Models.VMs
{
    public class UserDetailsVM
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string UserImage { get; set; }

        public DateTime UserCreatedDate { get; set; }
    }
}
