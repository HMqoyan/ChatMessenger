using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
