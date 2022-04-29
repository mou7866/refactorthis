using System.Collections.Generic;

namespace RefactorThis.Domain.Seedwork
{
    public class MessageBody
    {
        public ResponseType Type { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public bool Technical { get; set; }

        public List<string> Arguments { get; set; }

        public MessageBody()
        {
            Type = ResponseType.FAILURE;

            Arguments = new List<string>();
        }
    }
}
