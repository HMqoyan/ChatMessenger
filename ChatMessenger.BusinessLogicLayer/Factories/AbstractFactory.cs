﻿using AutoMapper;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Interfaces.UnitOfWorks;
using ChatMessenger.DataAccessLayer.Data;
using ChatMessenger.DataAccessLayer.UnitOfWorks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;

namespace ChatMessenger.BusinessLogicLayer.Factories
{
    public abstract class AbstractFactory : IDisposable
    {
        protected readonly IRepositoriesUnitOfWork _repos;
        protected readonly IMapper _mapper;
        protected readonly ChatMessengerDbContext _dbContext;

        public AbstractFactory(ChatMessengerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _repos = new RepositoriesUnitOfWork(dbContext);
            _mapper = mapper;
        }

        public abstract IAccountBL CreateAccountBL(IMemoryCache memoryCache, IConfiguration configuration);
        public abstract IMessageBL CreateMessageBL();

        public virtual void Dispose()
        {
            _repos.Dispose();
        }
    }
}
