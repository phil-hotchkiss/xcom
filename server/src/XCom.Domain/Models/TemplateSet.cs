namespace XCom.Domain.Models
{
    public class TemplateSet
    {
        public Guid Id { get; private set; }
        public string TemplateSetName { get; private set; }
        public List<string> Categories { get; private set; }
        public List<Variation> Variations { get; private set; }
        public RateLimit RateLimit { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private TemplateSet() { }

        public static TemplateSet Create(string templateSetName, List<string> categories, List<Variation> variations, RateLimit rateLimit = null)
        {
            var templateSet = new TemplateSet
            {
                Id = Guid.NewGuid(),
                TemplateSetName = templateSetName,
                Categories = categories ?? new List<string>(),
                Variations = variations ?? new List<Variation>(),
                RateLimit = rateLimit,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return templateSet;
        }

        public void Update(string templateSetName, List<string> categories, List<Variation> variations, RateLimit rateLimit)
        {
            TemplateSetName = templateSetName;
            Categories = categories ?? new List<string>();
            Variations = variations ?? new List<Variation>();
            RateLimit = rateLimit;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
