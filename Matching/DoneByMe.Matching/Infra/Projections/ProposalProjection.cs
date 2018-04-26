using System;
using DoneByMe.Matching.Model.Proposals;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Projections
{
    public class ProposalProjection : Projection, ISubscriber
	{
		public ProposalProjection()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			Topic topic = messageBus.OpenTopic("matching");
			topic.Subscribe(this);
		}

		public void Handle(Message message)
		{
			try
			{
                
				DomainEvent domainEvent = ToEvent<DomainEvent>(message);
				if (domainEvent.GetType() == typeof(PricingDenied)) Project((PricingDenied)domainEvent);
				if (domainEvent.GetType() == typeof(PricingVerified)) Project((PricingVerified)domainEvent);
				if (domainEvent.GetType() == typeof(ProposalSubmitted)) Project((ProposalSubmitted)domainEvent);
				if (domainEvent.GetType() == typeof(SchedulingDenied)) Project((SchedulingDenied)domainEvent);
				if (domainEvent.GetType() == typeof(SchedulingVerified)) Project((SchedulingVerified)domainEvent);
			} catch (Exception) {
				// TODO: handle
			}
		}

		private void Project(PricingDenied pricingDenied)
		{
			ProposalView view = ProposalView.Views[pricingDenied.ProposalId];
			ProposalView.Views.Add(pricingDenied.ProposalId, view.WithSchedulingDenied(pricingDenied.SuggestedPrice));
		}

		private void Project(PricingVerified pricingVerified)
		{
			ProposalView view = ProposalView.Views[pricingVerified.ProposalId];
			ProposalView.Views.Add(pricingVerified.ProposalId, view.WithProgress("PricingVerified"));
		}

		private void Project(ProposalSubmitted proposalSubmitted)
		{
			ProposalView.Views.Add(
				proposalSubmitted.ProposalId,
				new ProposalView(
					proposalSubmitted.ProposalId,
					proposalSubmitted.ClientId,
					proposalSubmitted.Summary,
					proposalSubmitted.Description,
					proposalSubmitted.CompletedBy,
					proposalSubmitted.CompletedBy,
					proposalSubmitted.Steps,
					proposalSubmitted.Price,
					proposalSubmitted.Price,
					new string[0]));
		}

		private void Project(SchedulingDenied schedulingDenied)
		{
			ProposalView view = ProposalView.Views[schedulingDenied.ProposalId];
			ProposalView.Views.Add(schedulingDenied.ProposalId, view.WithSchedulingDenied(schedulingDenied.SuggestedCompletionDate));
		}

		private void Project(SchedulingVerified schedulingVerified)
		{
			ProposalView view = ProposalView.Views[schedulingVerified.ProposalId];
			ProposalView.Views.Add(schedulingVerified.ProposalId, view.WithProgress("SchedulingVerified"));
		}
	}
}
