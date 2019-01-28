namespace ChatMessenger.Core.Common.Enums
{
    public enum CustomErrorEnum
    {
        EmptyEmail = 1,
        EmptyPassword = 2,
        EmailFormat = 3,
        InvalidPassword = 4,
        EmptyConfirmPassword = 5,
        PasswordMatch = 6,
        EmptyPartnerId = 7,
        PhoneNumberFormat = 8,
        LanguageIdMaxLength = 9,
        UsedEmail = 10,
        UnsuccessfulRegister = 11,
        UnsuccessfulLogIn = 12,
        UnsuccessfulResetPassword = 13,
        UnsuccessfulLogOut = 14,
        UnsuccessfulChangePassword = 15,
        TokenExpire = 16,
    }
}
