using System;
using System.Collections.Generic;

namespace DoneByMe.Matching.Model.Proposals
{
	public sealed class Expectations
	{
		public Description Description { get; private set; }

		public DateTime CompletedBy { get; private set; }

		public DateTime SuggestedCompletedBy { get; private set; }

		public Summary Summary { get; private set; }

		public ISet<Step> Steps { get; private set; }

        //keywords

		public long Price { get; private set; }

		public long SuggestedPrice { get; private set; }

		public static Expectations Of(Summary summary, Description description, DateTime completedBy, ISet<Step> steps, long price)
		{
			return new Expectations(summary, description, completedBy, steps, price);
		}

		public Expectations WithAdjusted(DateTime suggestedCompletedBy)
		{
			return new Expectations(Summary, Description, CompletedBy, suggestedCompletedBy, Steps, Price, SuggestedPrice);
		}

		public Expectations WithAdjusted(long suggestedPrice)
		{
			return new Expectations(Summary, Description, CompletedBy, SuggestedCompletedBy, Steps, Price, suggestedPrice);
		}

		public Expectations WithNew(Summary summary)
		{
			return new Expectations(summary, Description, CompletedBy, SuggestedCompletedBy, Steps, Price, SuggestedPrice);
		}

		public Expectations WithNew(Description description)
		{
			return new Expectations(Summary, description, CompletedBy, SuggestedCompletedBy, Steps, Price, SuggestedPrice);
		}

		public Expectations WithNew(Step step)
		{
			ISet<Step> newSteps = new HashSet<Step>();
			newSteps.Add(step);
			newSteps.UnionWith(Steps);
			return new Expectations(Summary, Description, CompletedBy, SuggestedCompletedBy, newSteps, Price, SuggestedPrice);
		}

		public override int GetHashCode()
		{
			return (Summary.GetHashCode()
						+ (Description.GetHashCode()
						+ (CompletedBy.GetHashCode() + Steps.GetHashCode())));
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Expectations))
			{
				return false;
			}

			Expectations otherExpectations = (Expectations)other;

			return Summary.Equals(otherExpectations.Summary)
					&& Description.Equals(otherExpectations.Description)
					&& CompletedBy.Equals(CompletedBy) && Steps.Equals(otherExpectations.Steps);
		}

		public override string ToString()
		{
			return "Expectations[summary="
					+ Summary + " Description="
					+ Description + " CompletedBy="
					+ CompletedBy + " Steps="
					+ Steps + "]";
		}

		internal static String[] Convert(ISet<Step> steps)
		{
			string[] plainSteps = new String[steps.Count];
			int idx = 0;
			foreach (Step step in steps)
			{
				plainSteps[idx] = "" + step.Sequence + "=" + step.Description;
			}

			return plainSteps;
		}

		internal static ISet<Step> Convert(string[] plainSteps)
		{
			ISet<Step> steps = new HashSet<Step>();
            if (plainSteps == null)
            {
                return steps;
            }

			foreach (string plainStep in plainSteps)
			{
				string[] parts = plainStep.Split("=");
				steps.Add(Step.Ordered(int.Parse(parts[0]), Description.Has(parts[1])));
			}

			return steps;
		}

		private Expectations(Summary summary, Description description, DateTime completedBy, ISet<Step> steps, long price)
		{
			Summary = summary;
			Description = description;
			CompletedBy = completedBy;
			SuggestedCompletedBy = completedBy;
			Steps = steps;
			Price = price;
			SuggestedPrice = price;
		}

		private Expectations(Summary summary, Description description, DateTime completedBy, DateTime suggestedCompletedBy, ISet<Step> steps, long price, long suggestedPrice)
		{
			Summary = summary;
			Description = description;
			CompletedBy = completedBy;
			SuggestedCompletedBy = completedBy;
			Steps = steps;
			Price = price;
			SuggestedPrice = suggestedPrice;
		}
	}
}

