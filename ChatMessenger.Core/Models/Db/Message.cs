using ChatMessenger.Core.Interfaces.Models.Db;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatMessenger.Core.Models.Db
{
    public class Message : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int ToId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool Deleted { get; set; }
    }
}
