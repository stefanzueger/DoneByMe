using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
    public class ProposalSubmitted : DomainEvent
    {
		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public string Description { get; private set; }
		public string Summary { get; private set; }
		public long CompletedBy { get; private set; }
		public string[] Steps { get; private set; }
		public long Price { get; private set; }

        public ProposalSubmitted() { }

        public static ProposalSubmitted Instance(
			Id proposalId,
			Client client,
			Expectations expectations)
		{
            ProposalSubmitted proposalSubmitted = new ProposalSubmitted
            {
                ProposalId = proposalId.Value,
                ClientId = client.Id.Value,
                Summary = expectations.Summary.Text,
                Description = expectations.Description.Text,
                CompletedBy = expectations.CompletedBy.Ticks,
                Steps = Expectations.Convert(expectations.Steps),
                Price = expectations.Price
            };

            return proposalSubmitted;
		}
	}
}
