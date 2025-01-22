using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XCom.Application.Commands.SendEmail;
using XCom.Domain.Models;
using XCom.Models;

namespace XCom.Controllers
{
    public class MailApiImpl : MailApiController
    {
        private readonly ISendEmailCommandHandler _sendEmailCommandHandler;

        public MailApiImpl(ISendEmailCommandHandler sendEmailCommandHandler)
        {
            _sendEmailCommandHandler = sendEmailCommandHandler;
        }

        public override async Task<IActionResult> SendSimpleEmail([FromBody] SimpleMailRequest simpleMailRequest)
        {
            var command = new SendEmailCommand
            {
                From = EmailRecipient.Create(simpleMailRequest.From.Email, simpleMailRequest.From.Name),
                To = simpleMailRequest.To.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                Cc = simpleMailRequest.Cc?.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                Bcc = simpleMailRequest.Bcc?.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                Subject = simpleMailRequest.Subject,
                Content = simpleMailRequest.Content.Value,
                ContentType = simpleMailRequest.Content.Type == Models.Content.TypeEnum.HtmlEnum ? ContentType.Html : ContentType.PlainText,
                ReplyTo = simpleMailRequest.ReplyTo.Email
            };

            var result = await _sendEmailCommandHandler.HandleAsync(command);

            if (result.IsSuccess)
            {
                return Ok(new MailResponse { Message = "Email sent successfully" });
            }

            return BadRequest(new ErrorResponse 
            { 
                Error = new ResponseError(){
                    Message = "Failed to send email",
                    Errors = result.Errors.Select(e => new ResponseErrorModel { Message = e.Message }).ToList()
                }
            });
        }

        public override async Task<IActionResult> SendTemplatedEmail([FromBody] TemplatedEmailRequest templatedEmailRequest)
        {
            var command = new SendTemplatedEmailCommand
            {
                From = EmailRecipient.Create(templatedEmailRequest.From.Email, templatedEmailRequest.From.Name),
                To = templatedEmailRequest.To.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                Cc = templatedEmailRequest.Cc?.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                Bcc = templatedEmailRequest.Bcc?.Select(r => EmailRecipient.Create(r.Email, r.Name)).ToList(),
                TemplateSetName = templatedEmailRequest.TemplateSetName,
                BusinessKey = templatedEmailRequest.BusinessKey,
                OnBehalfOfBranch = templatedEmailRequest.OnBehalfOfBranch,
                TemplateData = (Dictionary<string, object>)templatedEmailRequest.TemplateData,
                ReplyTo = templatedEmailRequest.ReplyTo.Email
            };

            var result = await _sendEmailCommandHandler.HandleAsync(command);

            if (result.IsSuccess)
            {
                return Ok(new MailResponse { Message = "Email sent successfully" });
            }

            return BadRequest(new ErrorResponse 
            { 
                Error = new ResponseError()
                {
                    Message = "Failed to send templated email",
                    Errors = result.Errors.Select(e => new ResponseErrorModel { Message = e.Message }).ToList()
                }
            });
        }
    }
}
