using System;

namespace DoneByMe.Matching.Model
{
    public class Summary
    {
		public string Text { get; private set; }
  
		public static Summary Has(string text)
		{
			return new Summary(text);
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

		private Summary(String text)
		{
			Text = text;
		}
	}
}
