using System.Collections.Generic;
using DoneByMe.Matching.Infra.Projections;

namespace DoneByMe.Matching.Query
{
    public class ProposalQuery
    {
		public ProposalView Proposal(string proposalId)
		{
			return ProposalView.Get(proposalId);
		}

		public List<ProposalView> Proposals(string clientId)
		{
			return ProposalView.GetAllFor(clientId);
		}
	}
}
