using System.Collections.Generic;

namespace DoneByMe.Matching.Infra.Projections
{
    public class ProposalView
    {
		// memory cached proposal views
		private static Dictionary<string, ProposalView> views;
		internal static Dictionary<string, ProposalView> Views
		{
			get
			{
				if (views == null)
				{
					views = new Dictionary<string, ProposalView>();
				}
				return views;
			}
		}

		public static ProposalView Get(string proposalId)
		{
			return views[proposalId];
		}

		public static List<ProposalView> GetAllFor(string clientId)
		{
			// there could be a different map for this kind
			// of view, but just saving time in example
			List<ProposalView> clientProposalViews = new List<ProposalView>();
			foreach (ProposalView view in views.Values)
			{
				if (view.ClientId.Equals(clientId))
				{
					clientProposalViews.Add(view);
				}
			}

			return clientProposalViews;
		}

		public string ProposalId { get; private set; }
		public string ClientId { get; private set; }
		public string Description { get; private set; }
		public string Summary { get; private set; }
		public long CompletedBy { get; private set; }
		public long SuggestedCompletedBy { get; private set; }
		public string[] Steps { get; private set; }
		public long Price { get; private set; }
		public long SuggestedPrice { get; private set; }
		public string[] Progress { get; private set; }

		internal ProposalView(
			string proposalId,
			string clientId,
			string description,
			string summary,
			long completedBy,
			long suggestedCompletedBy,
			string[] steps,
			long price,
			long suggestedPrice,
			string[] progress)
		{

			ProposalId = proposalId;
			ClientId = clientId;
			Description = description;
			Summary = summary;
			CompletedBy = completedBy;
			SuggestedCompletedBy = suggestedCompletedBy;
			Steps = steps;
			Price = price;
			SuggestedPrice = suggestedPrice;
			Progress = progress;
		}

		protected ProposalView(
			ProposalView proposalView,
			long suggestedCompletedBy,
			long suggestedPrice,
			string[] newProgress)
			: this(
				proposalView.ProposalId,
				proposalView.ClientId,
				proposalView.Description,
				proposalView.Summary,
				proposalView.CompletedBy,
				suggestedCompletedBy,
				proposalView.Steps,
				proposalView.Price,
				suggestedPrice,
				newProgress)
		{
		}

		protected ProposalView(ProposalView proposalView, string[] newProgress)
			: this(
				proposalView.ProposalId,
				proposalView.ClientId,
				proposalView.Description,
				proposalView.Summary,
				proposalView.CompletedBy,
				proposalView.SuggestedCompletedBy,
				proposalView.Steps,
				proposalView.Price,
				proposalView.SuggestedPrice,
				newProgress)
		{
		}

		internal ProposalView WithProgress(string progress)
		{
			return new ProposalView(this, WithNewProgress(progress));
		}

		internal ProposalView WithSchedulingDenied(
			long suggestedCompletedBy)
		{
			return new ProposalView(
				this,
				suggestedCompletedBy,
				SuggestedPrice,
				WithNewProgress("SchedulingDenied"));
		}

		internal ProposalView WithPricingDenied(
			long suggestedPrice)
		{
			return new ProposalView(
				this,
				SuggestedCompletedBy,
				suggestedPrice,
				WithNewProgress("PricingDenied"));
		}

		private string[] WithNewProgress(string progress)
		{
			List<string> current = new List<string>(Progress);
			current.Add(progress);
			return current.ToArray();
		}
	}
}
