using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
    public class SchedulingVerified : DomainEvent
    {
		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public long CompletionDate { get; private set; }

        public SchedulingVerified() { }

        public static SchedulingVerified Instance(
			Id proposalId,
			Client client,
			Expectations expectations)
		{
            SchedulingVerified schedulingVerified = new SchedulingVerified
            {
                ProposalId = proposalId.Value,
                ClientId = client.Id.Value,
                CompletionDate = expectations.CompletedBy.Ticks
            };

            return schedulingVerified;

        }
	}
}
