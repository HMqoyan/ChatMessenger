using ChatMessenger.Core.Interfaces.UnitOfWorks;
using System;

namespace ChatMessenger.BusinessLogicLayer.BusinessLogics
{
    internal abstract class BaseBL : IDisposable
    {
        protected readonly IRepositoriesUnitOfWork _repos;

        public BaseBL(IRepositoriesUnitOfWork repos)
        {
            _repos = repos;
        }

        public virtual void Dispose()
        {
            _repos.Dispose();
        }
    }
}
