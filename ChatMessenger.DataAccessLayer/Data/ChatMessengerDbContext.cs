using ChatMessenger.Core.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace ChatMessenger.DataAccessLayer.Data
{
    public class ChatMessengerDbContext : DbContext
    {
        public ChatMessengerDbContext(DbContextOptions<ChatMessengerDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
