using ChatMessenger.Core.Interfaces.Models.Db;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatMessenger.Core.Models.Db
{
    public class User : IEntity
    {
        public User()
        {
            Messages = new List<Message>();
            UserTokenSessions = new List<UserTokenSession>();
        }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public DateTime Modified { get; set; }
        public string UniqueKey { get; set; }
        [Required]
        public string Password { get; set; }
        public bool EmailIsVerified { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserTokenSession> UserTokenSessions { get; set; }
    }
}
