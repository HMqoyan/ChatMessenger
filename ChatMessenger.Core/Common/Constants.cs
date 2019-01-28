using System;
using System.Collections.Generic;
using System.Text;

namespace ChatMessenger.Core.Common
{
    public static class Constants
    {
        public static class CustomErrors
        {
            public const string EmptyEmailErrorMessage = "Email is required";
            public const string EmailFormatErrorMessage = "Email is not in the correct format";
            public const string EmptyPasswordErrorMessage = "Password is required";
            public const string InvalidPasswordErrorMessage = "Password is invalid";
            public const string EmptyConfirmPasswordErrorMessage = "Confirm your password";
            public const string PasswordMatchErrorMessage = "Passwords don't match";
            public const string EmptyPartnerIdErrorMessage = "PartnerId is required";
            public const string PhoneNumberFormatErrorMessage = "Phone number is not in the correct format";
            public const string LanguageIdMaxLengthErrorMessage = "Use maximum 2 characters";
            public const string UsedEmailErrorMessage = "The email is used";
            public const string UnsuccessfulRegisterErrorMessage = "Unsuccessful registration";
            public const string UnsuccessfulLogInErrorMessage = "Can't find your account";
            public const string UnsuccessfulResetPasswordErrorMessage = "Can't reset your password";
            public const string UnsuccessfulLogOutErrorMessage = "Can't log out of your account";
            public const string UnsuccessfulChangePasswordErrorMessage = "Can't change your password";
            public const string TokenExpireErrorMessage = "Your token has expired. Please login again";
        }
    }
}
