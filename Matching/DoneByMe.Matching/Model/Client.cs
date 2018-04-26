namespace DoneByMe.Matching.Model
{
    public class Client
    {
		public Id Id;

		public static Client From(string referencedId)
		{
			return new Client(Id.FromExisting(referencedId));
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Client))
			{
				return false;
			}
    
			return this.Id.Equals(((Client) other).Id);
		}

		public override string ToString()
		{
			return "Client[Id=" + Id + "]";
		}

		private Client(Id id)
		{
			Id = id;
		}
	}
}
