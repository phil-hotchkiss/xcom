using System.Threading.Tasks;
using FluentResults;
using XCom.Application.Services;
using XCom.Domain.Interfaces;
using XCom.Domain.Models;

namespace XCom.Application.Commands.SendEmail
{
    public interface ISendEmailCommandHandler
    {
        Task<Result> HandleAsync(SendEmailCommand command);
        Task<Result> HandleAsync(SendTemplatedEmailCommand command);
    }

    public class SendEmailCommandHandler : ISendEmailCommandHandler
    {
        private readonly IEmailService _emailService;
        private readonly ITemplateSetRepository _templateSetRepository;
        private readonly ITemplateSelectionService _templateSelectionService;

        public SendEmailCommandHandler(
            IEmailService emailService,
            ITemplateSetRepository templateSetRepository,
            ITemplateSelectionService templateSelectionService)
        {
            _emailService = emailService;
            _templateSetRepository = templateSetRepository;
            _templateSelectionService = templateSelectionService;
        }

        public async Task<Result> HandleAsync(SendEmailCommand command)
        {
            var email = Email.Create(
                command.From,
                command.To,
                EmailContent.Create(command.Subject, command.Content, command.ContentType),
                command.Cc,
                command.Bcc,
                replyTo: command.ReplyTo
            );

            return await _emailService.SendEmailAsync(email);
        }

        public async Task<Result> HandleAsync(SendTemplatedEmailCommand command)
        {
            // Get template set
            var templateSets = await _templateSetRepository.GetByQueryAsync(null, command.TemplateSetName);
            if (templateSets == null || templateSets.Count == 0)
            {
                return Result.Fail($"Template set '{command.TemplateSetName}' not found");
            }

            var templateSet = templateSets[0];

            // Check rate limit if business key is provided
            if (!string.IsNullOrEmpty(command.BusinessKey) && templateSet.RateLimit != null)
            {
                // TODO: Implement rate limiting
            }

            // Select template variation
            var selectedTemplate = _templateSelectionService.SelectTemplate(templateSet.Variations);
            if (selectedTemplate == null)
            {
                return Result.Fail("No active template variation found");
            }

            // Create email
            var email = Email.Create(
                command.From,
                command.To,
                null,
                command.Cc,
                command.Bcc,
                command.TemplateData,
                command.ReplyTo
            );

            // Send email using selected template
            return await _emailService.SendTemplatedEmailAsync(email, selectedTemplate.SendGridTemplateId);
        }
    }
}
