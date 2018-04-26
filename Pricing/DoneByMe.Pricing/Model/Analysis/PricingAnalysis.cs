using System.Collections.Generic;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingAnalysis : EventSourcedRootEntity
	{
		public Id Id { get; private set; }

		public PricingAnalysis(List<DomainEvent> events, int streamVersion)
			: base(events, streamVersion) 
		{
		}
	}
}
