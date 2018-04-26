using DoneByMe.Pricing.Infra.Messaging;
using DoneByMe.Pricing.Infra.Persistence;

namespace DoneByMe.Pricing.Infra
{
    public class StartUp
    {
		public static void Start()
		{
			PricingJournal.Start();
			PricingJournalPublisher.Start();
			MatchingContextSubscriber.Start();
		}
    }
}
