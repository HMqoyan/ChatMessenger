using ChatMessenger.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace ChatMessenger.Core.Models.Presentation.Account.LogIn
{
    public class UserLogInModelIn
    {
        [Required(ErrorMessage = Constants.CustomErrors.EmptyEmailErrorMessage)]
        [DataType(DataType.EmailAddress, ErrorMessage =Constants.CustomErrors.EmailFormatErrorMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = Constants.CustomErrors.EmptyPasswordErrorMessage)]
        [DataType(DataType.Password, ErrorMessage = Constants.CustomErrors.InvalidPasswordErrorMessage)]
        public string Password { get; set; }
    }
}
