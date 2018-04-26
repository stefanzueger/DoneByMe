using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Messaging
{
    public class PricingContextSubscriber : ISubscriber
    {
		private static PricingContextSubscriber instance;

		private Topic pricingTopic;
  
		public static PricingContextSubscriber Start()
		{
			if (instance == null)
			{
				instance = new PricingContextSubscriber();
			}
			return instance;
		}

		public void Handle(Message message)
		{
			if (message.Type.Contains("PricingVerified"))
			{
				MessageExchangeReader reader = MessageExchangeReader.From(message);
				string proposalId = reader.PayloadStringValue("originatorId");

				API.ProposalCommands.VerifyPricing(proposalId);

			}
			else if (message.Type.Contains("PricingRejected"))
			{
				MessageExchangeReader reader = MessageExchangeReader.From(message);
				string proposalId = reader.PayloadStringValue("originatorId");
				long suggestedPrice = reader.PayloadLongValue("suggestedPrice");

				API.ProposalCommands.DenyPricing(proposalId, suggestedPrice);
			}
		}

		private PricingContextSubscriber()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			this.pricingTopic = messageBus.OpenTopic("pricing");

			pricingTopic.Subscribe(this);
		}
	}
}
