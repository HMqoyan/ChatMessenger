using ChatMessenger.Core.Common;
using ChatMessenger.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatMessenger.Core.Models.Presentation
{
    public class ErrorModel
    {
        private CustomErrorEnum _customStatusCode;
        private string _errorMessage;

        public virtual CustomErrorEnum CustomStatusCode
        {
            get
            {
                return _customStatusCode;
            }
            set
            {
                _customStatusCode = value;

                if (string.IsNullOrEmpty(_errorMessage))
                {
                    _errorMessage = String.Empty;
                    Dictionaries.ErrorStatusMessage.TryGetValue(value, out _errorMessage);
                }
            }
        }

        public virtual string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;

                if (CustomStatusCode == 0)
                {
                    CustomStatusCode = Dictionaries.ErrorStatusMessage.FirstOrDefault(e => e.Value == _errorMessage).Key;
                }
            }
        }
    }
}
