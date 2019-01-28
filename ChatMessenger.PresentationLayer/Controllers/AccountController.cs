using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace ChatMessenger.PresentationLayer.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public AccountController(ChatMessengerDbContext dbContext,
                                 IMapper mapper,
                                 IMemoryCache memoryCache,
                                 IConfiguration configuration)
            : base(dbContext, mapper)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
