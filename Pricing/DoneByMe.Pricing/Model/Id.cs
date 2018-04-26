using System;

namespace DoneByMe.Pricing.Model
{
	public class Id
    {
		public static Id FromExisting(string referencedId)
		{
			return new Id(referencedId);
		}

		public static Id Unique()
		{
			return new Id();
		}

		public string Value { get; private set; }

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Id))
			{
				return false;
			}
    
			Id otherId = (Id) other;
    
			return this.Value.Equals(otherId.Value);
		}

		public override string ToString()
		{
			return "Id[Value=" + Value + "]";
		}

		private Id()
		{
			this.Value = Guid.NewGuid().ToString();
		}

		private Id(string referencedId)
		{
			this.Value = referencedId;
		}
	}
}
