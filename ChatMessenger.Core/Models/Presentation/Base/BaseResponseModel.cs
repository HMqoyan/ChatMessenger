using ChatMessenger.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatMessenger.Core.Models.Presentation.Base
{
    public abstract class BaseResponseModel
    {
        public List<ErrorModel> ErrorList { get; protected set; }

        public BaseResponseModel()
        {
            ErrorList = new List<ErrorModel>();
        }

        public virtual bool HasError
        {
            get
            {
                return ErrorList.Any();
            }
        }

        public virtual void AddError(ErrorModel errorModel)
        {
            ErrorList.Add(errorModel);
        }

        public virtual void AddError(CustomErrorEnum customStatusCode)
        {
            ErrorList.Add(new ErrorModel()
            {
                CustomStatusCode = customStatusCode
            });
        }
    }
}
