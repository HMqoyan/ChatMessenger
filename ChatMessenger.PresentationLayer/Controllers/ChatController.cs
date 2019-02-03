using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.Core.Interfaces.Repositories;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.Core.Models.Presentation;
using ChatMessenger.DataAccessLayer.Data;
using ChatMessenger.DataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatMessenger.PresentationLayer.Controllers
{
    public class ChatController : BaseController
    {
        RepositoriesUnitOfWork _unitOfWork;

                public ChatController(ChatMessengerDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _unitOfWork = new RepositoriesUnitOfWork(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            ICollection<User> users= await _unitOfWork.Users.GetAllAsync();
            ICollection<Message> messages = await _unitOfWork.Messages.GetMessageByFromIdAndToIdAsync(1,2);
            _unitOfWork.Users = (IUserRepository)users;
            _unitOfWork.Messages = (IMessageRepository)messages;
            return View(_unitOfWork);
        }
    }
}
