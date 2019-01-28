using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Interfaces.UnitOfWorks;

namespace ChatMessenger.BusinessLogicLayer.BusinessLogics
{
    internal class AccountBL : BaseBL, IAccountBL
    {
        public AccountBL(IRepositoriesUnitOfWork repos, IMapper mapper) 
            : base(repos, mapper)
        {
        }
    }
}
