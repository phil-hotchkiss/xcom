using System.Collections.Generic;
using XCom.Domain.Models;

namespace XCom.Application.Commands.SendEmail
{
    public class SendEmailCommand
    {
        public EmailRecipient From { get; set; }
        public List<EmailRecipient> To { get; set; }
        public List<EmailRecipient> Cc { get; set; }
        public List<EmailRecipient> Bcc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public string ReplyTo { get; set; }
    }

    public class SendTemplatedEmailCommand : SendEmailCommand
    {
        public string TemplateSetName { get; set; }
        public string BusinessKey { get; set; }
        public string OnBehalfOfBranch { get; set; }
        public Dictionary<string, object> TemplateData { get; set; }
    }
}
