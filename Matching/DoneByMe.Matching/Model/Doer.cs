namespace DoneByMe.Matching.Model
{
    public class Doer
    {
		public Id Id { get; private set; }
		public bool Preferred { get; private set; }
  
		public static Doer NonPreferredFrom(string referencedId)
		{
			return new Doer(Id.FromExisting(referencedId), false);
		}

		public static Doer PreferredFrom(string referencedId)
		{
			return new Doer(Id.FromExisting(referencedId), true);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode() + (Preferred ? 1 : 0);
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Doer))
			{
				return false;
			}
    
			Doer otherDoer = (Doer) other;
    
			return this.Id.Equals(otherDoer.Id) && this.Preferred == otherDoer.Preferred;
		}

		public override string ToString()
		{
			return "Doer[Id=" + Id + " Preferred=" + Preferred + "]";
		}

		private Doer(Id id, bool preferred)
		{
			this.Id = id;
			this.Preferred = preferred;
		}
	}
}
