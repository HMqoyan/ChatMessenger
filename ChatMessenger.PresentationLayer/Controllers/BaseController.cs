using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.BusinessLogicLayer.Factories;
using ChatMessenger.DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChatMessenger.PresentationLayer.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly AbstractFactory _blFactory;
        protected readonly IMapper _mapper;

        public BaseController(ChatMessengerDbContext dbContext, IMapper mapper)
        {
            _blFactory = new BLFactory(dbContext, mapper);
            _mapper = mapper;
        }

        protected override void Dispose(bool disposing)
        {
            _blFactory.Dispose();
            base.Dispose(disposing);
        }
    }
}