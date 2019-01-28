using ChatMessenger.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace ChatMessenger.Core.Models.Presentation.Account.ResetPassword
{
    public class ResetPasswordModelIn
    {
        [Required(ErrorMessage = Constants.CustomErrors.EmptyPasswordErrorMessage)]
        [DataType(DataType.Password, ErrorMessage = Constants.CustomErrors.InvalidPasswordErrorMessage)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = Constants.CustomErrors.EmptyPasswordErrorMessage)]
        [DataType(DataType.Password, ErrorMessage = Constants.CustomErrors.InvalidPasswordErrorMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = Constants.CustomErrors.EmptyConfirmPasswordErrorMessage)]
        [DataType(DataType.Password, ErrorMessage = Constants.CustomErrors.InvalidPasswordErrorMessage)]
        [Compare(nameof(Password), ErrorMessage = Constants.CustomErrors.PasswordMatchErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
