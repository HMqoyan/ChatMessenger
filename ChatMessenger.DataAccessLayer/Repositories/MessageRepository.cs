using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.DataAccessLayer.Data;

namespace ChatMessenger.DataAccessLayer.Repositories
{
    internal class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatMessengerDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
