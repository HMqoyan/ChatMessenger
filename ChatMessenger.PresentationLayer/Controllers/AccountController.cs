using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChatMessenger.PresentationLayer.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ChatMessengerDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
