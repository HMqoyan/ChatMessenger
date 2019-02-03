using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatMessenger.DataAccessLayer.Repositories
{
    internal class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatMessengerDbContext dbContext)
            : base(dbContext)
        {
        }


        //public async Task<Message> GetMessageByFromIdAndToIdAsync(int fromId, int toId)
        //{
        //  return await _dbSet.Where(wc => ((wc.Id == fromId && wc.ToId == toId) || (wc.Id == toId && wc.ToId == fromId))).AsQueryable<Message>; 
        //}

        public async Task<ICollection<Message>> GetMessageByFromIdAndToIdAsync(int fromId, int toId)
        {
            return await _dbSet.Where<Message>(wc => ((wc.UserId == fromId && wc.ToId == toId) || (wc.UserId == toId && wc.ToId == fromId))).ToListAsync<Message>();

        }

    }
}
