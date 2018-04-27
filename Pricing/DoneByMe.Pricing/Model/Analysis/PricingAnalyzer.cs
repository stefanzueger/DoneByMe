using System;
using System.Linq;
using DoneByMe.Pricing.Infra.Persistence;

// Domain Service
namespace DoneByMe.Pricing.Model.Analysis
{
    public class PricingAnalyzer
    {
		public void AnalyzePricing(string pricedItemId, long price, string[] keywords)
		{
			// TODO: process in this Domain Service and keep PricingHistory
			Console.WriteLine("PricingAnalyzer#AnalyzePricing(" + pricedItemId + ", " + price + ")");

		    var pricingAnalysis = keywords.Contains("#windows") ? 
		        PricingAnalysis.VerifyFor(pricedItemId, price) : 
		        PricingAnalysis.RejectFor(pricedItemId, price, (long)(price * 0.9));

		    Repositories.PricingAnalysisRepository.Save(pricingAnalysis);
        }
	}
}
