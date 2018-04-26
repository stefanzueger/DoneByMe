using System;
using System.Collections.Generic;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Model.Proposals
{
    public class Proposal : EventSourcedRootEntity
    {
		public Id Id { get; private set; }
		public Client Client { get; private set; }
		public Expectations Expectations { get; private set; }
		public Progress Progress { get; private set; }

		public static Proposal SubmitFor(Client client, Expectations expectations)
		{
			return new Proposal(client, expectations);
		}

		public void DenyPricing(long suggestedPrice)
		{
			if (!Progress.WasPricingDenied())
			{
				Apply(PricingDenied.Instance(Id, Client, Expectations, suggestedPrice));
			}
		}

		public void DenyScheduling(DateTime suggestedCompletionDate)
		{
			if (!Progress.WasSchedulingDenied())
			{
				Apply(SchedulingDenied.Instance(Id, Client, Expectations, suggestedCompletionDate.Ticks));
			}
		}

		public void VerifyPricing()
		{
			if (!Progress.WasPricingVerified())
			{
				Apply(PricingVerified.Instance(Id, Client, Expectations));
			}
		}

		public void VerifyScheduling()
		{
			if (!Progress.WasSchedulingVerified())
			{
				Apply(SchedulingVerified.Instance(Id, Client, Expectations));
			}
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Proposal))
			{
				return false;
			}
    
			Proposal otherProposal = (Proposal) other;
    
			return this.Id.Equals(otherProposal.Id);
		}

		public override string ToString()
		{
			return "Proposal[Id=" + Id +
				" Client=" + Client +
				" Expectations=" + Expectations +
				" Progress=" + Progress + "]";
		}

		public void When(ProposalSubmitted proposalSubmitted)
		{
			Id = Id.FromExisting(proposalSubmitted.ProposalId);
			Client = Client.From(proposalSubmitted.ClientId);
			Expectations =
                Proposals.Expectations.Of(
					Summary.Has(proposalSubmitted.Summary),
					Description.Has(proposalSubmitted.Description),
					new DateTime(proposalSubmitted.CompletedBy),
					Expectations.Convert(proposalSubmitted.Steps),
					proposalSubmitted.Price);
			this.Progress = Progress.NONE;
		}

        public void When(PricingDenied deniedEvent)
		{
			this.Expectations = Expectations.WithAdjusted(deniedEvent.SuggestedPrice);
			this.Progress = Progress.DeniedForPricing();
		}

        public void When(PricingVerified pricingVerified)
		{
			this.Progress = Progress.VerifiedForPricing();
		}

        public void When(SchedulingDenied schedulingDenied)
		{
			this.Expectations = Expectations.WithAdjusted(schedulingDenied.SuggestedCompletionDate);
			this.Progress = Progress.DeniedForScheduling();
		}

        public void When(SchedulingVerified schedulingVerified)
		{
			this.Progress = Progress.VerifiedForScheduling();
		}

		private Proposal(Client client, Expectations expectations)
			: this(Id.Unique(), client, expectations, Progress.NONE)
		{
		}

		private Proposal(Id id, Client client, Expectations expectations, Progress progress)
		{
			Apply(ProposalSubmitted.Instance(id, client, expectations));
		}

		public Proposal(List<DomainEvent> stream, int streamVersion)
			: base(stream, streamVersion)
		{
		}
	}
}
