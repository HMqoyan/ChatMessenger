using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Models.Cache
{
    public class UserTokenSessionCacheModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string Device { get; set; }
        public string BrowserVersion { get; set; }
        public string IP { get; set; }
        public bool CloseActionIsLogout { get; set; }

        public int UserId { get; set; }
        public UserCacheModel User { get; set; }

        public bool Deleted { get; set; }
    }
}
