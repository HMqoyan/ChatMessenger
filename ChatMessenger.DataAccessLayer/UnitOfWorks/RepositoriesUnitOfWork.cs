using System.Threading.Tasks;
using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Interfaces.UnitOfWorks;
using ChatMessenger.DataAccessLayer.Data;
using ChatMessenger.DataAccessLayer.Repositories;

namespace ChatMessenger.DataAccessLayer.UnitOfWorks
{
    public class RepositoriesUnitOfWork : IRepositoriesUnitOfWork
    {
        protected readonly ChatMessengerDbContext _dbContext;
        protected IUserRepository _userRepository;
        protected IUserTokenSessionRepository _userTokenSessionRepository;
        protected IMessageRepository _messageRepository;


        public RepositoriesUnitOfWork(ChatMessengerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);

                return _userRepository;
            }
        }

        public virtual IUserTokenSessionRepository UserTokenSessions
        {
            get
            {
                if (_userTokenSessionRepository == null)
                    _userTokenSessionRepository = new UserTokenSessionRepository(_dbContext);

                return _userTokenSessionRepository;
            }
        }

        public IMessageRepository Messages
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(_dbContext);

                return _messageRepository;
            }
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
