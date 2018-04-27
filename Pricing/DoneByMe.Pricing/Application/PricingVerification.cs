using DoneByMe.Pricing.Model.Analysis;

// Application Service
namespace DoneByMe.Pricing.Application
{
    public class PricingVerification

    {
		public PricingVerification()
		{
		}

		public void VerifyPricing(string pricedItemId, long price, string[] keywords)
		{
			new PricingAnalyzer().AnalyzePricing(pricedItemId, price, keywords);
		}
	}
}
