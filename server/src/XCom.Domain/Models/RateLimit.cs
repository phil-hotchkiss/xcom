namespace XCom.Domain.Models
{
    public class RateLimit
    {
        public decimal Period { get; private set; }
        public decimal Limit { get; private set; }

        private RateLimit() { }

        public static RateLimit Create(decimal period, decimal limit)
        {
            return new RateLimit
            {
                Period = period,
                Limit = limit
            };
        }
    }
}
