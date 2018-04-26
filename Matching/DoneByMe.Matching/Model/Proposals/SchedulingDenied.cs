using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
    public class SchedulingDenied : DomainEvent
    {
		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public long CompletionDate { get; private set; }
		public long SuggestedCompletionDate { get; private set; }

        public SchedulingDenied() { }

        public static SchedulingDenied Instance(
			Id proposalId,
			Client client,
			Expectations expectations,
			long suggestedCompletionDate)
		{
            SchedulingDenied schedulingDenied = new SchedulingDenied
            {
                ProposalId = proposalId.Value,
                ClientId = client.Id.Value,
                CompletionDate = expectations.CompletedBy.Ticks,
                SuggestedCompletionDate = suggestedCompletionDate
            };

            return schedulingDenied;

        }
	}
}
