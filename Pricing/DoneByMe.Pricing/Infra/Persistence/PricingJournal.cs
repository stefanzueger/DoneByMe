using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Infra.Persistence
{
    public class PricingJournal
    {
        private static EventJournal eventJournal = EventJournal.Open("donebyme-pricing");
		public static EventJournal EventJournal { get { return eventJournal; } }
  
		public static void Start() { }

		public static void Stop()
		{
			EventJournal.Close();
		}
	}
}
