using DoneByMe.Matching.Model;
using DoneByMe.Matching.Model.Proposals;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Persistence
{
	public class JournalProposalRepository : EventSourceRepository, ProposalRepository
	{
		private EventJournal journal;
		private EventStreamReader reader;

		public Proposal ProposalOf(Id id)
		{
			EventStream stream = reader.StreamFor(id.Value);

			return new Proposal(ToEvents(stream.Stream), stream.StreamVersion);
		}

		public void Save(Proposal proposal)
		{
			journal.Write(proposal.Id.Value, proposal.MutatedVersion, ToBatch(proposal.MutatingEvents));
		}

		internal JournalProposalRepository()
		{
			this.journal = EventJournal.Open("donebyme-matching");
			this.reader = this.journal.StreamReader();
		}
	}
}
