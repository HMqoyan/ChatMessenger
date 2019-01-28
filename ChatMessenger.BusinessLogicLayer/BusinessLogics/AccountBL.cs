using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ChatMessenger.Common.Utilities;
using ChatMessenger.Core.Common;
using ChatMessenger.Core.Common.Enums;
using ChatMessenger.Core.Interfaces.BusinessLogics;
using ChatMessenger.Core.Interfaces.UnitOfWorks;
using ChatMessenger.Core.Models.Cache;
using ChatMessenger.Core.Models.Db;
using ChatMessenger.Core.Models.Presentation;
using ChatMessenger.Core.Models.Presentation.Account.LogIn;
using ChatMessenger.Core.Models.Presentation.Account.LogOut;
using ChatMessenger.Core.Models.Presentation.Account.Register;
using ChatMessenger.Core.Models.Presentation.Account.ResetPassword;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace ChatMessenger.BusinessLogicLayer.BusinessLogics
{
    internal class AccountBL : BaseBL, IAccountBL
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private static DateTimeOffset? _cacheExpirationByMinutes;

        public AccountBL(IRepositoriesUnitOfWork repos,
                         IMapper mapper,
                         IMemoryCache memoryCache,
                         IConfiguration configuration)
            : base(repos, mapper)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;

            if (_cacheExpirationByMinutes == null)
            {
                int minutes = Int32.Parse(_configuration.GetSection("AppSettings")
                                                        .GetSection("ClientLogInCacheExpirationByMinutes")
                                                        .Value);

                _cacheExpirationByMinutes = DateTimeOffset.UtcNow.AddMinutes(minutes);
            }
        }

        public async Task CheckingEmailExists(string email, UserRegisterModelOut response)
        {
            if (await _repos.Users.CheckingEmailExists(email))
            {
                response.AddError(CustomErrorEnum.UsedEmail);
            }
        }

        public async Task Register(UserModel userModel, UserRegisterModelOut response)
        {
            User user = _mapper.Map<User>(userModel);

            await _repos.Users.Create(user);

            if (await _repos.SaveAsync() == 0)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulRegister);
            }
        }

        public async Task<UserLogInModelOut> LogIn(UserLogInModelIn modelIn, UserTokenSessionModel userTokenSessionModel)
        {
            UserTokenSession userTokenSession = _mapper.Map<UserTokenSession>(userTokenSessionModel);

            UserLogInModelOut response = new UserLogInModelOut();

            User user = await _repos.Users.GetUserByEmailAndPassword(modelIn.Email, modelIn.Password);

            if (user == null)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulLogIn);

                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.EmailIsVerified = user.EmailIsVerified;
            response.PhoneNumber = user.PhoneNumber;
            response.Token = HashingUtilities.GetHashSHA512(Guid.NewGuid().ToString());

            userTokenSession.UserId = user.Id;
            userTokenSession.Date = DateTime.UtcNow;
            userTokenSession.LastUpdateDate = DateTime.UtcNow;
            userTokenSession.Token = response.Token;

            await _repos.UserTokenSessions.Create(userTokenSession);

            if (await _repos.SaveAsync() == 0)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulLogIn);

                return response;
            }

            UserTokenSessionCacheModel clientTokenSessionCacheModel = _mapper.Map<UserTokenSessionCacheModel>(userTokenSession);

            _memoryCache.Set(response.Token, clientTokenSessionCacheModel, _cacheExpirationByMinutes.Value);

            return response;
        }

        public async Task ChangePassword(string token, string oldPassword, string newPassword, ResetPasswordModelOut response)
        {

            if (!_memoryCache.TryGetValue(token, out UserTokenSessionCacheModel session))
            {
                response.AddError(CustomErrorEnum.TokenExpire);

                return;
            }

            User user = await _repos.Users.GetByIdAsync(session.UserId);

            if (user == null)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulLogIn);

                return;
            }

            if (user.Password != oldPassword)
            {
                response.AddError(CustomErrorEnum.InvalidPassword);

                return;
            }

            user.Password = newPassword;

            _repos.Users.Update(user);

            if (await _repos.SaveAsync() == 0)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulChangePassword);

                return;
            }
        }

        public async Task LogOut(string token, UserLogOutModelOut response)
        {
            if (!_memoryCache.TryGetValue(token, out UserTokenSessionCacheModel userTokenSessionCacheModel))
            {
                response.AddError(CustomErrorEnum.TokenExpire);

                return;
            }

            UserTokenSession session = await _repos.UserTokenSessions.GetByIdAsync(userTokenSessionCacheModel.Id);

            session.CloseActionIsLogout = true;

            _repos.UserTokenSessions.Update(session);

            if (await _repos.SaveAsync() == 0)
            {
                response.AddError(CustomErrorEnum.UnsuccessfulLogOut);
            }
        }
    }
}
