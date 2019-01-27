using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.DTO
{
    public class UserDTO : IdentityUser<int>
    {
        public UserDTO()
        {
            Messages = new List<MessageDTO>();
        }

        public bool Deleted { get; set; }

        public ICollection<MessageDTO> Messages { get; set; }

    }
}
