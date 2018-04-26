using System;

// Domain Service
namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingAnalyzer
    {
		public void AnalyzePricing(string pricedItemId, long price)
		{
			// TODO: process in this Domain Service and keep PricingHistory
			Console.WriteLine("PricingAnalyzer#AnalyzePricing(" + pricedItemId + ", " + price + ")");
		}
	}
}
