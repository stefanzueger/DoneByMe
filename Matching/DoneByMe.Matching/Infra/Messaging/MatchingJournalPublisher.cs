using DoneByMe.Matching.Infra.Persistence;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Messaging
{
	public class MatchingJournalPublisher
	{
		private static EventJournalPublisher journalPublisher;

		public static void Start()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			Topic topic = messageBus.OpenTopic("matching");

			journalPublisher =
				EventJournalPublisher.From(
					MatchingJournal.eventJournal.Name,
					messageBus.Name,
					topic.Name);
		}

		public static void Stop()
		{
			journalPublisher.Close();
		}
	}
}
