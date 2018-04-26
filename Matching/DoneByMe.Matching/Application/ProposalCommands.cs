using System;
using System.Collections.Generic;
using DoneByMe.Matching.Model;
using DoneByMe.Matching.Model.Proposals;

namespace DoneByMe.Matching.Application
{
    public class ProposalCommands
    {
		private ProposalRepository repository;
  
		public ProposalCommands(ProposalRepository repository)
		{
			this.repository = repository;
		}

		public void DenyPricing(
			string proposalId,
			long suggestedPrice)
		{

			Proposal proposal = repository.ProposalOf(Id.FromExisting(proposalId));

			proposal.DenyPricing(suggestedPrice);

			repository.Save(proposal);
		}

		public void DenyScheduling(
			string proposalId,
			DateTime suggestedCompletionDate)
		{

			Proposal proposal = repository.ProposalOf(Id.FromExisting(proposalId));

			proposal.DenyScheduling(suggestedCompletionDate);

			repository.Save(proposal);
		}

		public void SubmitProposal(
			string clientId,
			string summary,
			string description,
			DateTime completedBy,
			Dictionary<int, string> steps,
			long price)
		{

			Proposal proposal =
				Proposal.SubmitFor(
					Client.From(clientId),
					Expectations.Of(
						Summary.Has(summary),
						Description.Has(description),
						completedBy,
						Step.From(steps),
						price));

			repository.Save(proposal);
		}

		public void VerifyPricing(string proposalId)
		{
			Proposal proposal = repository.ProposalOf(Id.FromExisting(proposalId));

			proposal.VerifyPricing();

			repository.Save(proposal);
		}

		public void VerifyScheduling(string proposalId)
		{
			Proposal proposal = repository.ProposalOf(Id.FromExisting(proposalId));

			proposal.VerifyScheduling();

			repository.Save(proposal);
		}
	}
}
