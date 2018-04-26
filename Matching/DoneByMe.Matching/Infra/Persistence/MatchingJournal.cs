using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Persistence
{
    public class MatchingJournal
    {
		public static EventJournal eventJournal;
  
		public static void Start()
		{
			eventJournal = EventJournal.Open("donebyme-matching");
		}

		public static void stop()
		{
			eventJournal.Close();
		}
	}
}
