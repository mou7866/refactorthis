using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RefactorThis.Domain.Seedwork
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Errors = new List<MessageBody>();
        }

        public List<MessageBody> Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess => !Errors.Any();

        public void SetError(string errorMessage, bool resetErrors = false)
        {
            if (resetErrors)
                Errors = new List<MessageBody>();

            Errors.Add(new MessageBody
            {
                Technical = true,
                Type = ResponseType.FAILURE,
                Code = "error",
                Message = errorMessage
            });
        }

        public void SetResultException(Exception ex)
        {
            Errors.Add(new MessageBody
            {
                Technical = true,
                Type = ResponseType.FAILURE,
                Code = "error",
                Message = ex.Message
            });
        }

        public void SetNotFoundError(Exception ex = null)
        {
            Errors.Add(new MessageBody
            {
                Technical = true,
                Type = ResponseType.FAILURE,
                Code = "not_found",
                Message = ex is not null ? ex.Message : "Sorry we could not find anything for that"
            });
        }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public void SetResult()
        {
            if (Data is null)
            {
                SetNotFoundError();
            }
        }
    }
}
