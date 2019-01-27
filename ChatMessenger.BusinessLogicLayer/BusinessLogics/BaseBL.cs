using AutoMapper;
using ChatMessenger.Core.Interfaces.UnitOfWorks;
using System;

namespace ChatMessenger.BusinessLogicLayer.BusinessLogics
{
    internal abstract class BaseBL : IDisposable
    {
        protected readonly IRepositoriesUnitOfWork _repos;
        protected readonly IMapper _mapper;

        public BaseBL(IRepositoriesUnitOfWork repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        
        public virtual void Dispose()
        {
            _repos.Dispose();
        }
    }
}
