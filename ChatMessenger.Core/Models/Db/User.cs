using ChatMessenger.Core.Interfaces.Models.Db;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ChatMessenger.Core.Models.Db
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            Messages = new List<Message>();
        }

        public virtual ICollection<Message> Messages { get; set; }

        public bool Deleted { get; set; }
    }
}
