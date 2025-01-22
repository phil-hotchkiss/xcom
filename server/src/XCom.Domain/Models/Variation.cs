namespace XCom.Domain.Models
{
    public class Variation
    {
        public string SendGridTemplateId { get; private set; }
        public float Percentage { get; private set; }
        public bool IsActive { get; private set; }

        private Variation() { }

        public static Variation Create(string sendGridTemplateId, float percentage, bool isActive = true)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100", nameof(percentage));

            return new Variation
            {
                SendGridTemplateId = sendGridTemplateId,
                Percentage = percentage,
                IsActive = isActive
            };
        }

        public void Update(string sendGridTemplateId, float percentage, bool isActive)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Percentage must be between 0 and 100", nameof(percentage));

            SendGridTemplateId = sendGridTemplateId;
            Percentage = percentage;
            IsActive = isActive;
        }
    }
}
