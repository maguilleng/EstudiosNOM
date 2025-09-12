using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class EmailModel
    {
            //public EmailModel(string to, string subject, string message, bool isBodyHtml)
            //{
            //    To = to;
            //    Subject = subject;
            //    Message = message;
            //    IsBodyHtml = isBodyHtml;
            //}
            public string To { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
            public bool IsBodyHtml { get; set; }
    }
}
