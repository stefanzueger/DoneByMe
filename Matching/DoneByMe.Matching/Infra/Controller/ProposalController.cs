using System;
using System.Collections.Generic;
using DoneByMe.Matching.Infra.Projections;
using DoneByMe.Matching.Query;

namespace DoneByMe.Matching.Infra.Controller
{
    public class ProposalController
    {
		public ProposalView Get(string proposalId)
		{
			return new ProposalQuery().Proposal(proposalId);
		}

		public List<ProposalView> GetForClient(string clientId)
		{
			return new ProposalQuery().Proposals(clientId);
		}

		public void Submit(
			string clientId,
			string summary,
			string description,
			DateTime completedBy,
			Dictionary<int, string> steps,
			long price)
		{

			API.ProposalCommands
			  .SubmitProposal(
				clientId,
				summary,
				description,
				completedBy,
				steps,
				price);
		}
	}
}
