using System;

namespace DoneByMe.Matching.Model
{
    public class Description
    {
		public string Text { get; private set; }
  
		public static Description Has(string text)
		{
			return new Description(text);
		}

		public override int GetHashCode()
		{
			return Text.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other == null || other.GetType() != typeof(Summary))
			{
				return false;
			}
    
			return this.Text.Equals(((Summary) other).Text);
		}

		public override string ToString()
		{
			return "Summary[Text=" + Text + "]";
		}

		private Description(string text)
		{
			Text = text;
		}
	}
}
