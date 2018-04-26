using System.Collections.Generic;

namespace DoneByMe.Matching.Model.Proposals
{
    public class Progress
    {
		public static Progress NONE = new Progress();

		enum Spec
		{
			PricingDenied,
			PricingVerified,
			SchedulingDenied,
			SchedulingVerified,
			Submitted
		}

		private ISet<Spec> specs;

		public bool IsAcceptable()
		{
			return WasSubmitted() && WasPricingVerified() && WasSchedulingVerified();
		}

		public bool IsUnacceptable()
		{
			return WasSubmitted() && WasPricingDenied() || WasSchedulingDenied();
		}

		public bool WasPricingDenied()
		{
			return specs.Contains(Spec.PricingDenied);
		}

		public bool WasPricingVerified()
		{
			return specs.Contains(Spec.PricingVerified);
		}

		public bool WasSchedulingDenied()
		{
			return specs.Contains(Spec.SchedulingDenied);
		}

		public bool WasSchedulingVerified()
		{
			return specs.Contains(Spec.SchedulingVerified);
		}

		public bool WasSubmitted()
		{
			return specs.Contains(Spec.Submitted);
		}

		public override int GetHashCode()
		{
			return specs.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Progress)) {
				return false;
			}
    
			Progress otherProgress = (Progress) other;
    
			return this.specs.Equals(otherProgress.specs);
		}

		public override string ToString()
		{
			return "Progress[specs=" + specs + "]";
		}

		internal Progress DeniedForPricing()
		{
			return WithNewSpec(Spec.PricingDenied);
		}

		internal Progress DeniedForScheduling()
		{
			return WithNewSpec(Spec.SchedulingDenied);
		}

		internal Progress SubmittedByClient()
		{
			return WithOnlySpec(Spec.Submitted);
		}

		internal Progress VerifiedForPricing()
		{
			return WithNewSpec(Spec.PricingVerified);
		}

		internal Progress VerifiedForScheduling()
		{
			return WithNewSpec(Spec.SchedulingVerified);
		}

		private Progress WithNewSpec(Spec spec)
		{
			ISet<Spec> newSpecs = new HashSet<Spec>(this.specs);
			newSpecs.Add(spec);
			return new Progress(newSpecs);
		}

		private Progress WithOnlySpec(Spec spec)
		{
			ISet<Spec> newSpecs = new HashSet<Spec>();
			newSpecs.Add(spec);
			return new Progress(newSpecs);
		}

		private Progress()
		{
			this.specs = new HashSet<Spec>();
		}

		private Progress(ISet<Spec> specs)
		{
			this.specs = specs;
		}
	}
}
