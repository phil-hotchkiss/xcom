using System;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using XCom.Domain.Models;
using XCom.Domain.Interfaces;

namespace XCom.Application.Commands.CreateTemplateSet
{
    public interface ICreateTemplateSetCommandHandler
    {
        Task<Result<TemplateSet>> HandleAsync(CreateTemplateSetCommand command);
    }

    public class CreateTemplateSetCommandHandler : ICreateTemplateSetCommandHandler
    {
        private readonly ITemplateSetRepository _templateSetRepository;

        public CreateTemplateSetCommandHandler(ITemplateSetRepository templateSetRepository)
        {
            _templateSetRepository = templateSetRepository;
        }

        public async Task<Result<TemplateSet>> HandleAsync(CreateTemplateSetCommand command)
        {
            // Validate total percentage is 100%
            var totalPercentage = command.Variations.Sum(v => v.Percentage);
            if (Math.Abs(totalPercentage - 100) > 0.01f)
            {
                return Result.Fail("Total percentage of variations must equal 100%");
            }

            // Create variations
            var variations = command.Variations.Select(v => 
                Variation.Create(v.SendGridTemplateId, v.Percentage)).ToList();

            // Create rate limit if provided
            var rateLimit = command.RateLimit != null
                ? RateLimit.Create(command.RateLimit.Period, command.RateLimit.Limit)
                : null;

            // Create template set
            var templateSet = TemplateSet.Create(
                command.TemplateSetName,
                command.Categories,
                variations,
                rateLimit);

            // Save to repository
            await _templateSetRepository.AddAsync(templateSet);

            return Result.Ok(templateSet);
        }
    }
}
