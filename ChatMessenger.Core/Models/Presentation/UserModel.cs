using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.Presentation
{
    public class UserModel : IdentityUser<int>
    {
        public UserModel()
        {
            Messages = new List<MessageModel>();
        }

        public bool Deleted { get; set; }

        public ICollection<MessageModel> Messages { get; set; }

    }
}
