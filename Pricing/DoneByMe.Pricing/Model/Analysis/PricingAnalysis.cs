using System.Collections.Generic;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingAnalysis : EventSourcedRootEntity
	{
		public Id Id { get; private set; }

	    public long Price { get; set; }

	    public long SuggestedPrice { get; set; }

	    public bool Verified { get; set; }

	    public static PricingAnalysis VerifyFor(string pricedItemId, long price)
	    {
	        return new PricingAnalysis(Id.FromExisting(pricedItemId), price);
	    }

	    public static PricingAnalysis RejectFor(string pricedItemId, long price, long suggestedPrice)
	    {
	        return new PricingAnalysis(Id.FromExisting(pricedItemId), price, suggestedPrice);
	    }

	    public void When(PricingVerified pricingVerified)
	    {
	        this.Id = Id.FromExisting(pricingVerified.OriginatorId);
	        this.Price = pricingVerified.Price;
	        this.Verified = true;
	    }

	    public void When(PricingRejected pricingRejected)
	    {
	        this.Id = Id.FromExisting(pricingRejected.OriginatorId);
	        this.Price = pricingRejected.Price;
	        this.SuggestedPrice = pricingRejected.SuggestedPrice;
	        this.Verified = false;
	    }

        private PricingAnalysis(Id pricedItemId, long price)
	    {
	        Apply(PricingVerified.Instance(pricedItemId, price));
        }

	    private PricingAnalysis(Id pricedItemId, long price, long suggestedPrice)
	    {
            Apply(PricingRejected.Instance(pricedItemId, price, suggestedPrice));
	    }

        public PricingAnalysis(List<DomainEvent> events, int streamVersion)
			: base(events, streamVersion) 
		{
		}
	}
}
