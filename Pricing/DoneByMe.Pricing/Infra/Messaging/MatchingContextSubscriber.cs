using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Infra.Messaging
{
	public class MatchingContextSubscriber : ISubscriber
	{
		private static MatchingContextSubscriber instance;

		private Topic matchingTopic;

		public static MatchingContextSubscriber Start()
		{
			if (instance == null)
			{
				instance = new MatchingContextSubscriber();
			}
			return instance;
		}

		public void Handle(Message message)
		{
			if (message.Type.Contains("ProposalSubmitted"))
			{
				MessageExchangeReader reader = MessageExchangeReader.From(message);
				string proposalId = reader.PayloadStringValue("proposalId");
				long price = reader.PayloadLongValue("price");
                // TODO: dispatch with full parameters (currently not full)
                // for example, matching proposal keywords[] are
                // needed by the pricing engine (verification)
                API.PricingVerification.VerifyPricing(proposalId, price);
			}
		}

		private MatchingContextSubscriber()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			this.matchingTopic = messageBus.OpenTopic("matching");

			matchingTopic.Subscribe(this);
		}
	}
}
