using AutoMapper;
using ChatMessenger.BusinessLogicLayer.BusinessLogics;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.DataAccessLayer.Data;

namespace ChatMessenger.BusinessLogicLayer.Factories
{
    public class BLFactory : AbstractFactory
    {
        public BLFactory(ChatMessengerDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public override IMessageBL CreateMessageBL()
        {
            return new MessageBL(_repos, _mapper);
        }

        public override IUserBL CreateUserBL()
        {
            return new UserBL(_repos, _mapper);
        }
    }
}
