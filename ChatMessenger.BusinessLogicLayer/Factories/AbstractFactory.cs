using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Interfaces.UnitOfWorks;
using ChatMessenger.DataAccessLayer.Data;
using ChatMessenger.DataAccessLayer.UnitOfWorks;
using System;

namespace ChatMessenger.BusinessLogicLayer.Factories
{
    public abstract class AbstractFactory : IDisposable
    {
        protected readonly IRepositoriesUnitOfWork _repos;
        protected readonly ChatMessengerDbContext _dbContext;

        public AbstractFactory(ChatMessengerDbContext dbContext)
        {
            _dbContext = dbContext;
            _repos = new RepositoriesUnitOfWork(dbContext);
        }

        public abstract IUserBL CreateUserBL();
        public abstract IMessageBL CreateMessageBL();

        public virtual void Dispose()
        {
            _repos.Dispose();
        }
    }
}
