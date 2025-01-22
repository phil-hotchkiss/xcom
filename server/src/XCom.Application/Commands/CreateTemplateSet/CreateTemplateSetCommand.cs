using System.Collections.Generic;
using FluentResults;

namespace XCom.Application.Commands.CreateTemplateSet
{
    public class CreateTemplateSetCommand
    {
        public string TemplateSetName { get; set; }
        public List<string> Categories { get; set; }
        public List<VariationDto> Variations { get; set; }
        public RateLimitDto RateLimit { get; set; }
    }

    public class VariationDto
    {
        public string SendGridTemplateId { get; set; }
        public float Percentage { get; set; }
    }

    public class RateLimitDto
    {
        public decimal Period { get; set; }
        public decimal Limit { get; set; }
    }
}
