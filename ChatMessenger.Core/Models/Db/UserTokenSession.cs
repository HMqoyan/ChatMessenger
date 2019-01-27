using ChatMessenger.Core.Interfaces.Models.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatMessenger.Core.Models.Db
{
    public class UserTokenSession : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string Device { get; set; }
        public string BrowserVersion { get; set; }
        public string IP { get; set; }
        public bool CloseActionIsLogout { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool Deleted { get; set; }
    }
}
