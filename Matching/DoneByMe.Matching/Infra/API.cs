using DoneByMe.Matching.Application;
using DoneByMe.Matching.Infra.Persistence;

namespace DoneByMe.Matching.Infra
{
    public class API
    {
		private static ProposalCommands proposalCommands;
		public static ProposalCommands ProposalCommands
		{
			get
			{
				if (proposalCommands == null)
				{
					proposalCommands = new ProposalCommands(Repositories.ProposalRepository);
				}
				return proposalCommands;
			}
		}
	}
}
