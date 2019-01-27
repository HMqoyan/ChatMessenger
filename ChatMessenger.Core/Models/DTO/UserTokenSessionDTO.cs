using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.DTO
{
    public class UserTokenSessionDTO
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
        public UserDTO User { get; set; }

        public bool Deleted { get; set; }
    }
}
