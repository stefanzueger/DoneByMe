using System.Collections.Generic;

namespace DoneByMe.Matching.Model.Proposals
{
    public class Step
    {
		public int Sequence { get; private set; }
		public Description Description { get; private set; }

		public static ISet<Step> CopyAllOf(ISet<Step> existingTasks)
		{
			ISet<Step> copy = new HashSet<Step>();

			foreach (Step each in existingTasks)
			{
				copy.Add(Step.Ordered(each.Sequence, each.Description));
			}

			return copy;
		}

		public static ISet<Step> From(Dictionary<int, string> expectations)
		{
			ISet<Step> steps = new HashSet<Step>();

			foreach (int sequence in expectations.Keys)
			{
				string text = expectations[sequence];
				steps.Add(Step.Ordered(sequence, Description.Has(text)));
			}

			return steps;
		}

		public static Step Ordered(int sequence, Description description)
		{
			return new Step(sequence, description);
		}

		public override int GetHashCode()
		{
			return Sequence + Description.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Step))
			{
				return false;
			}
    
			Step otherStep = (Step) other;
    
			return Sequence == otherStep.Sequence && Description.Equals(otherStep.Description);
		}

		public override string ToString()
		{
			return "Step[Sequence=" + Sequence + " Description=" + Description + "]";
		}

		private Step(int sequence, Description description)
		{
			Sequence = sequence;
			Description = description;
		}
	}
}
