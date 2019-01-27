using AutoMapper;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Interfaces.UnitOfWorks;

namespace ChatMessenger.BusinessLogicLayer.BusinessLogics
{
    internal class MessageBL : BaseBL, IMessageBL
    {
        public MessageBL(IRepositoriesUnitOfWork repos, IMapper mapper) 
            : base(repos, mapper)
        {
        }
    }
}
