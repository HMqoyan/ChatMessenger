using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Models.Presentation
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ToId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public bool Deleted { get; set; }
    }
}
