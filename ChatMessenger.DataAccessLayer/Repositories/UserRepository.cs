using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.DataAccessLayer.Data;

namespace ChatMessenger.DataAccessLayer.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ChatMessengerDbContext dbContext) 
            : base(dbContext)
        {

        }
    }
}
