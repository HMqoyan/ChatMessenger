using ChatMessenger.Core.Models.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Interfaces.Repositories
{
    public interface IUserTokenSessionRepository : IGenericRepository<UserTokenSession>
    {
        Task<UserTokenSession> GetClientTokenSessionByTokenAsync(string token);
    }
}
