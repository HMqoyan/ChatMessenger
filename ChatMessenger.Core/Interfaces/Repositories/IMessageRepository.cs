using ChatMessenger.Core.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Interfaces.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<ICollection<Message>> GetMessageByFromIdAndToIdAsync(int fromId, int toId);
    }
}
