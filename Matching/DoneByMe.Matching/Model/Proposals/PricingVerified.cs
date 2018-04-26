using System;
using System.Collections.Generic;
using System.Text;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
	public class PricingVerified : DomainEvent
	{
		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public long Price { get; private set; }

        public PricingVerified() { }

        public static PricingVerified Instance(
			  Id proposalId,
			  Client client,
			  Expectations expectations)
		{
            PricingVerified pricingVerified = new PricingVerified
            {
                ProposalId = proposalId.Value,
                ClientId = client.Id.Value,
                Price = expectations.Price
            };

            return pricingVerified;
        }
	}
}
