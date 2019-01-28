using ChatMessenger.Core.Models.Presentation.Base;

namespace ChatMessenger.Core.Models.Presentation.Account.LogIn
{
    public class UserLogInModelOut : BaseResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailIsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
    }
}
