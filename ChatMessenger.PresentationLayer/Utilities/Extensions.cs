using ChatMessenger.Core.Models.Presentation;
using ChatMessenger.Core.Models.Presentation.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatMessenger.PresentationLayer.Utilities
{
    public static class Extensions
    {
        public static void IsValid(this ModelStateDictionary modelState, BaseResponseModel response)
        {
            var modelErrors = modelState.Values.Select(ms => ms.Errors);

            List<string> errorMessages = new List<string>();

            foreach (var item in modelErrors)
            {
                errorMessages.AddRange(item.Select(me => me.ErrorMessage));
            }

            foreach (var item in errorMessages)
            {
                response.AddError(new ErrorModel
                {
                    ErrorMessage = item
                });
            }
        }

        public static UserTokenSessionModel GetSessionData(this HttpRequest request)
        {
            return new UserTokenSessionModel()
            {
                //Browser = request.Browser.Browser,
                //BrowserVersion = request.Browser.Version,
                //IP = request.UserHostAddress,
                //OS = request.Browser.Platform,
                Device = request.Headers["User-Agent"].ToString()
            };
        }
    }
}
