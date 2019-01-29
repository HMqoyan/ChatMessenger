using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.Common.Utilities;
using ChatMessenger.Core.Common;
using ChatMessenger.Core.Common.Enums;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Models.Presentation;
using ChatMessenger.Core.Models.Presentation.Account.LogIn;
using ChatMessenger.Core.Models.Presentation.Account.LogOut;
using ChatMessenger.Core.Models.Presentation.Account.Register;
using ChatMessenger.Core.Models.Presentation.Account.ResetPassword;
using ChatMessenger.DataAccessLayer.Data;
using ChatMessenger.PresentationLayer.Utilities;
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


        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterModelIn modelIn)
        {
            UserRegisterModelOut response = new UserRegisterModelOut();

            ModelState.IsValid(response);

            if (response.HasError)
            {
                return Ok(response);
            }

            if (modelIn.Password != modelIn.ConfirmPassword)
            {
                response.AddError(CustomErrorEnum.PasswordMatch);

                return Ok(response);
            }

            IAccountBL accountBL = _blFactory.CreateAccountBL(_memoryCache, _configuration);

            await accountBL.CheckingEmailExists(modelIn.Email, response);

            if (response.HasError)
            {
                return Ok(response);
            }

            UserModel newUser = new UserModel
            {
                Email = modelIn.Email,
                Password = HashingUtilities.GetHashSHA512(modelIn.Password),
                PhoneNumber = modelIn.PhoneNumber,
                Modified = DateTime.UtcNow,
                UniqueKey = Guid.NewGuid().ToString(),
                EmailIsVerified = false,
                Deleted = false,
            };

            await accountBL.Register(newUser, response);

            if (response.HasError)
            {
                return Ok(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public IActionResult UserLogIn()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogIn(UserLogInModelIn modelIn)
        {
            UserLogInModelOut response = new UserLogInModelOut();

            ModelState.IsValid(response);

            if (response.HasError)
            {
                return Ok(response);
            }

            IAccountBL accountBL = _blFactory.CreateAccountBL(_memoryCache, _configuration);

            modelIn.Password = HashingUtilities.GetHashSHA512(modelIn.Password);

            UserTokenSessionModel userTokenSessionModel = Request.GetSessionData();

            response = await accountBL.LogIn(modelIn, userTokenSessionModel);

            if (response.HasError)
            {
                return Ok(response);
            }

            return RedirectToAction("Home/Index");
        }


        [HttpGet]
        public IActionResult UserChangePassword()
        {
            return View();
        }

        [HttpPost]
        //[UserAutorize]
        public async Task<IActionResult> UserChangePassword(ResetPasswordModelIn modelIn)
        {
            ResetPasswordModelOut response = new ResetPasswordModelOut();

            ModelState.IsValid(response);
            if (response.HasError)
            {
                return Ok(response);
            }

            if (modelIn.Password != modelIn.ConfirmPassword)
            {
                response.AddError(CustomErrorEnum.PasswordMatch);

                return Ok(response);
            }

            string token = Request.Headers[Constants.Token].ToString();

            IAccountBL accountBL = _blFactory.CreateAccountBL(_memoryCache, _configuration);

            await accountBL.ChangePassword(token, HashingUtilities.GetHashSHA512(modelIn.OldPassword),
                                           HashingUtilities.GetHashSHA512(modelIn.Password), response);

            if (response.HasError)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulChangePassword);

                return Ok(response);
            }

            return Ok(response);
        }

        [HttpPost]
        //[UserAutorize]
        public async Task<IActionResult> UserLogOut()
        {
            UserLogOutModelOut response = new UserLogOutModelOut();

            string token = Request.Headers[Constants.Token].ToString();

            IAccountBL accountBL = _blFactory.CreateAccountBL(_memoryCache, _configuration);

            await accountBL.LogOut(token, response);

            return Ok(response);
        }
        
    }
}
