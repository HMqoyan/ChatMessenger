using System.ComponentModel.DataAnnotations;

namespace ChatMessenger.Core.Interfaces.Models.Db
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }

        [Required]
        bool Deleted { get; set; }
    }
}
