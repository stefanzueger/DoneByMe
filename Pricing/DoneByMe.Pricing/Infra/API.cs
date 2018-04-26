using DoneByMe.Pricing.Application;

namespace DoneByMe.Pricing.Infra
{
	public class API
	{
		private static PricingVerification pricingVerification;
		public static PricingVerification PricingVerification
        {
			get
			{
				if (pricingVerification == null)
				{
					pricingVerification = new PricingVerification();
				}
				return pricingVerification;
			}
		}
	}
}
