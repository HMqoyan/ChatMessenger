using ChatMessenger.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Common
{
    public static class Dictionaries
    {

        private readonly static Dictionary<CustomErrorEnum, string> _errorStatusMessage;
        public static Dictionary<CustomErrorEnum, string> ErrorStatusMessage
        {
            get
            {
                return _errorStatusMessage;
            }
        }

        static Dictionaries()
        {
            _errorStatusMessage = new Dictionary<CustomErrorEnum, string>()
            {
                {CustomErrorEnum.EmptyEmail, Constants.CustomErrors.EmptyEmailErrorMessage },
                {CustomErrorEnum.EmailFormat, Constants.CustomErrors.EmailFormatErrorMessage },
                {CustomErrorEnum.EmptyPassword, Constants.CustomErrors.EmptyPasswordErrorMessage },
                {CustomErrorEnum.InvalidPassword, Constants.CustomErrors.InvalidPasswordErrorMessage },
                {CustomErrorEnum.EmptyConfirmPassword, Constants.CustomErrors.EmptyConfirmPasswordErrorMessage },
                {CustomErrorEnum.PasswordMatch, Constants.CustomErrors.PasswordMatchErrorMessage },
                {CustomErrorEnum.EmptyPartnerId, Constants.CustomErrors.EmptyPartnerIdErrorMessage },
                {CustomErrorEnum.PhoneNumberFormat, Constants.CustomErrors.PhoneNumberFormatErrorMessage },
                {CustomErrorEnum.LanguageIdMaxLength, Constants.CustomErrors.LanguageIdMaxLengthErrorMessage },
                {CustomErrorEnum.UsedEmail, Constants.CustomErrors.UsedEmailErrorMessage },
                {CustomErrorEnum.UnsuccessfulRegister, Constants.CustomErrors.UnsuccessfulRegisterErrorMessage },
                {CustomErrorEnum.UnsuccessfulLogIn, Constants.CustomErrors.UnsuccessfulLogInErrorMessage },
                {CustomErrorEnum.UnsuccessfulResetPassword, Constants.CustomErrors.UnsuccessfulResetPasswordErrorMessage },
                {CustomErrorEnum.UnsuccessfulLogOut, Constants.CustomErrors.UnsuccessfulLogOutErrorMessage },
                {CustomErrorEnum.UnsuccessfulChangePassword, Constants.CustomErrors.UnsuccessfulChangePasswordErrorMessage },
                {CustomErrorEnum.TokenExpire, Constants.CustomErrors.TokenExpireErrorMessage },
            };
        }
    }
}
