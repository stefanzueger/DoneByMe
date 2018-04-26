using DoneByMe.Pricing.Infra.Persistence;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Infra.Messaging
{
    public class PricingJournalPublisher
    {
		private static EventJournalPublisher journalPublisher;

		public static void Start()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			Topic topic = messageBus.OpenTopic("pricing");

			journalPublisher =
				EventJournalPublisher.From(
					PricingJournal.EventJournal.Name,
					messageBus.Name,
					topic.Name);
		}

		public static void Stop()
		{
			journalPublisher.Close();
		}
    }
}
