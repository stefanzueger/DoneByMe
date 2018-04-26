using DoneByMe.Pricing.Model;
using DoneByMe.Pricing.Model.Analysis;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Infra.Persistence
{
	public class JournalPricingAnalysisRepository : EventSourceRepository, PricingAnalysisRepository
	{
		private EventJournal journal;
		private EventStreamReader reader;

		public PricingAnalysis PricingAnalysisOf(Id id)
		{
			EventStream stream = reader.StreamFor(id.Value);

			return new PricingAnalysis(ToEvents(stream.Stream), stream.StreamVersion);
		}

		public void Save(PricingAnalysis pricingAnalysis)
		{
            journal.Write(pricingAnalysis.Id.Value, pricingAnalysis.MutatedVersion, ToBatch(pricingAnalysis.MutatingEvents));
        }

        internal JournalPricingAnalysisRepository()
		{
            this.journal = PricingJournal.EventJournal;
            this.reader = this.journal.StreamReader();
		}
	}
}
