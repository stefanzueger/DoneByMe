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
			    string[] keywords = reader.PayloadStringValue("keywords").Split(",");
                
			    API.PricingVerification.VerifyPricing(proposalId, price, keywords);
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
