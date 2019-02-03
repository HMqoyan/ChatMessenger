using AutoMapper;
using ChatMessenger.Core.Models.Cache;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.Core.Models.DTO;
using ChatMessenger.Core.Models.Presentation;

namespace ChatMessenger.Common.AutoMapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserTokenSession, UserTokenSessionDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();

            CreateMap<UserDTO, UserModel>().ReverseMap();
            CreateMap<UserTokenSessionDTO, UserTokenSessionModel>().ReverseMap();
            CreateMap<MessageDTO, MessageModel>().ReverseMap();

            CreateMap<UserDTO, UserCacheModel>().ReverseMap();
            CreateMap<UserTokenSessionDTO, UserTokenSessionCacheModel>().ReverseMap();

            //CreateMap<User, UserModel>().ReverseMap();
            //CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
