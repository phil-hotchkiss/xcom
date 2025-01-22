using XCom.Application.Services;
using XCom.Domain.Models;

namespace XCom.Infrastructure.Services
{
    public class TemplateSelectionService : ITemplateSelectionService
    {
        private readonly Random _random;

        public TemplateSelectionService()
        {
            _random = new Random();
        }

        public Variation SelectTemplate(List<Variation> variations)
        {
            if (variations == null || !variations.Any())
                throw new ArgumentException("Variations cannot be null or empty", nameof(variations));

            var randomValue = _random.NextDouble() * 100;
            var cumulativePercentage = 0.0f;

            foreach (var variation in variations.Where(v => v.IsActive))
            {
                cumulativePercentage += variation.Percentage;
                if (randomValue <= cumulativePercentage)
                {
                    return variation;
                }
            }

            return variations.Last(v => v.IsActive);
        }
    }
}
