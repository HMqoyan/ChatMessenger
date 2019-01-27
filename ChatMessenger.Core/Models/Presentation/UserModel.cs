using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.Presentation
{
    public class UserModel
    {
        public UserModel()
        {
            Messages = new List<MessageModel>();
            UserTokenSessions = new List<UserTokenSessionModel>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public DateTime Modified { get; set; }
        public string UniqueKey { get; set; }
        public string Password { get; set; }
        public bool EmailIsVerified { get; set; }

        public ICollection<MessageModel> Messages { get; set; }
        public ICollection<UserTokenSessionModel> UserTokenSessions { get; set; }

    }
}
