using System;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using SendGrid;
using SendGrid.Helpers.Mail;
using XCom.Domain.Interfaces;
using XCom.Domain.Models;

namespace XCom.Infrastructure.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public SendGridEmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task<Result> SendEmailAsync(Email email)
        {
            try
            {
                var msg = new SendGridMessage
                {
                    From = new EmailAddress(email.From.Email, email.From.Name),
                    Subject = email.Content.Subject,
                    HtmlContent = email.Content.Type == ContentType.Html ? email.Content.Content : null,
                    PlainTextContent = email.Content.Type == ContentType.PlainText ? email.Content.Content : null
                };

                AddRecipients(msg, email);

                if (!string.IsNullOrEmpty(email.ReplyTo))
                {
                    msg.ReplyTo = new EmailAddress(email.ReplyTo);
                }

                var response = await _sendGridClient.SendEmailAsync(msg);
                return response.IsSuccessStatusCode 
                    ? Result.Ok() 
                    : Result.Fail($"Failed to send email: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result> SendTemplatedEmailAsync(Email email, string templateId)
        {
            try
            {
                var msg = new SendGridMessage
                {
                    From = new EmailAddress(email.From.Email, email.From.Name),
                    Subject = email.Content.Subject,
                    TemplateId = templateId
                };

                AddRecipients(msg, email);

                if (!string.IsNullOrEmpty(email.ReplyTo))
                {
                    msg.ReplyTo = new EmailAddress(email.ReplyTo);
                }

                if (email.TemplateData.Any())
                {
                    msg.SetTemplateData(email.TemplateData);
                }

                var response = await _sendGridClient.SendEmailAsync(msg);
                return response.IsSuccessStatusCode 
                    ? Result.Ok() 
                    : Result.Fail($"Failed to send templated email: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private void AddRecipients(SendGridMessage msg, Email email)
        {
            msg.AddTos(email.To.Select(r => new EmailAddress(r.Email, r.Name)).ToList());
            
            if (email.Cc.Any())
            {
                msg.AddCcs(email.Cc.Select(r => new EmailAddress(r.Email, r.Name)).ToList());
            }

            if (email.Bcc.Any())
            {
                msg.AddBccs(email.Bcc.Select(r => new EmailAddress(r.Email, r.Name)).ToList());
            }
        }
    }
}
