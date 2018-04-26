using System;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
    public class PricingDenied : DomainEvent
    {
		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public long Price { get; private set; }
		public long SuggestedPrice { get; private set; }

        public PricingDenied() { }

        public static PricingDenied Instance(
            Id proposalId,
            Client client,
            Expectations expectations,
            long suggestedPrice)
        {
            PricingDenied pricingDenied = new PricingDenied
            {
                ProposalId = proposalId.Value,
                ClientId = client.Id.Value,
                Price = expectations.Price,
                SuggestedPrice = suggestedPrice
            };

            return pricingDenied;
		}
	}
}
