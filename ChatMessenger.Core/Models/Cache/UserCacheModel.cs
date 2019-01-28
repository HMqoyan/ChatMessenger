using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Models.Cache
{
    public class UserCacheModel
    {
        public UserCacheModel()
        {
            UserTokenSessions = new List<UserTokenSessionCacheModel>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public DateTime Modified { get; set; }
        public string UniqueKey { get; set; }
        public string Password { get; set; }
        public bool EmailIsVerified { get; set; }
        
        public ICollection<UserTokenSessionCacheModel> UserTokenSessions { get; set; }
    }
}
