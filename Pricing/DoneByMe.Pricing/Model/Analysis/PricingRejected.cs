using System;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingRejected : DomainEvent
    {
		public string OriginatorId { get; private set; }
		public long Price { get; private set; }
		public long SuggestedPrice { get; private set; }

        public PricingRejected() { }

        public static PricingRejected Instance(Id pricedItemId, long price, long suggestedPrice)
        {
            PricingRejected pricingRejected = new PricingRejected
            {
                OriginatorId = pricedItemId.Value,
                Price = price,
                SuggestedPrice = suggestedPrice
            };

            return pricingRejected;
		}
	}
}
