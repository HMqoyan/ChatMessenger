using ChatMessenger.Core.Models.Presentation;
using ChatMessenger.Core.Models.Presentation.Account.LogIn;
using ChatMessenger.Core.Models.Presentation.Account.LogOut;
using ChatMessenger.Core.Models.Presentation.Account.Register;
using ChatMessenger.Core.Models.Presentation.Account.ResetPassword;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessenger.Core.Interfaces.BusinessLogics
{
    public interface IAccountBL : IDisposable
    {
        Task CheckingEmailExists(string email, UserRegisterModelOut response);
        Task Register(UserModel userModel, UserRegisterModelOut response);
        Task<UserLogInModelOut> LogIn(UserLogInModelIn modelIn, UserTokenSessionModel userTokenSessionModel);
        Task ChangePassword(string token, string oldPassword, string newPassword, ResetPasswordModelOut response);
        Task LogOut(string token, UserLogOutModelOut response);
    }
}
