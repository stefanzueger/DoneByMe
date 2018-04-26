using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
	public class PricingVerified : DomainEvent
	{
		public string OriginatorId { get; private set; }
		public long Price { get; private set; }

        public PricingVerified() { }

        public static PricingVerified Instance(Id proposalId, long price)
		{
            PricingVerified pricingVerified = new PricingVerified
            {
                OriginatorId = proposalId.Value,
                Price = price
            };

            return pricingVerified;
        }
	}
}
