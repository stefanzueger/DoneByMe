using DoneByMe.Matching.Infra.Messaging;
using DoneByMe.Matching.Infra.Persistence;

namespace DoneByMe.Matching.Infra
{
    public class StartUp
    {
		public static void Start()
		{
			MatchingJournal.Start();
			MatchingJournalPublisher.Start();
			PricingContextSubscriber.Start();
			SchedulingContextSubscriber.Start();
		}
    }
}
