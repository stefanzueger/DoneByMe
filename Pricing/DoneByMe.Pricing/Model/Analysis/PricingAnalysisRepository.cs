namespace DoneByMe.Pricing.Model.Analysis
{
    public interface PricingAnalysisRepository
    {
		PricingAnalysis PricingAnalysisOf(Id id);
		void Save(PricingAnalysis pricingAnalysis);
	}
}
