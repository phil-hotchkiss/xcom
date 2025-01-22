using System.Collections.Generic;

namespace XCom.Domain.Models
{
    public class EmailRecipient
    {
        public string Email { get; private set; }
        public string Name { get; private set; }

        private EmailRecipient(string email, string name)
        {
            Email = email;
            Name = name;
        }

        public static EmailRecipient Create(string email, string name = null)
        {
            return new EmailRecipient(email, name);
        }
    }

    public enum ContentType
    {
        PlainText,
        Html
    }

    public class EmailContent
    {
        public string Subject { get; private set; }
        public string Content { get; private set; }
        public ContentType Type { get; private set; }

        private EmailContent(string subject, string content, ContentType type)
        {
            Subject = subject;
            Content = content;
            Type = type;
        }

        public static EmailContent Create(string subject, string content, ContentType type)
        {
            return new EmailContent(subject, content, type);
        }
    }

    public class Email
    {
        public EmailRecipient From { get; private set; }
        public List<EmailRecipient> To { get; private set; }
        public List<EmailRecipient> Cc { get; private set; }
        public List<EmailRecipient> Bcc { get; private set; }
        public EmailContent Content { get; private set; }
        public Dictionary<string, object> TemplateData { get; private set; }
        public string ReplyTo { get; private set; }

        private Email(
            EmailRecipient from,
            List<EmailRecipient> to,
            EmailContent content,
            List<EmailRecipient> cc = null,
            List<EmailRecipient> bcc = null,
            Dictionary<string, object> templateData = null,
            string replyTo = null)
        {
            From = from;
            To = to;
            Cc = cc ?? new List<EmailRecipient>();
            Bcc = bcc ?? new List<EmailRecipient>();
            Content = content;
            TemplateData = templateData ?? new Dictionary<string, object>();
            ReplyTo = replyTo;
        }

        public static Email Create(
            EmailRecipient from,
            List<EmailRecipient> to,
            EmailContent content,
            List<EmailRecipient> cc = null,
            List<EmailRecipient> bcc = null,
            Dictionary<string, object> templateData = null,
            string replyTo = null)
        {
            return new Email(from, to, content, cc, bcc, templateData, replyTo);
        }
    }
}
