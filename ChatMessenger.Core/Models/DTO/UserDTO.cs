using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Messages = new List<MessageDTO>();
            UserTokenSessions = new List<UserTokenSessionDTO>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public DateTime Modified { get; set; }
        public string UniqueKey { get; set; }
        public string Password { get; set; }
        public bool EmailIsVerified { get; set; }

        public ICollection<MessageDTO> Messages { get; set; }
        public ICollection<UserTokenSessionDTO> UserTokenSessions { get; set; }

    }
}
