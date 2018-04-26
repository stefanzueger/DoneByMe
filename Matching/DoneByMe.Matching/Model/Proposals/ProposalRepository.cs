namespace DoneByMe.Matching.Model.Proposals
{
    public interface ProposalRepository
    {
		Proposal ProposalOf(Id id);
		void Save(Proposal proposal);
	}
}
