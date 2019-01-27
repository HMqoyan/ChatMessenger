using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessenger.DataAccessLayer.Repositories
{
    internal class UserTokenSessionRepository : GenericRepository<UserTokenSession>, IUserTokenSessionRepository
    {
        public UserTokenSessionRepository(ChatMessengerDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<UserTokenSession> GetClientTokenSessionByTokenAsync(string token)
        {
            return await _dbSet.Where(cts => cts.Token == token &&
                                      !cts.CloseActionIsLogout).FirstOrDefaultAsync();
        }
    }
}
