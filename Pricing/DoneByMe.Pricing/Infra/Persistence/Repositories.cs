using DoneByMe.Pricing.Model.Analysis;

namespace DoneByMe.Pricing.Infra.Persistence
{
	public class Repositories
    {
		private static PricingAnalysisRepository pricingAnalysisRepository;
		public static PricingAnalysisRepository PricingAnalysisRepository
        {
			get
			{
				if (pricingAnalysisRepository == null)
				{
                    pricingAnalysisRepository = new JournalPricingAnalysisRepository();
				}
				return pricingAnalysisRepository;
			}
		}
	}
}
