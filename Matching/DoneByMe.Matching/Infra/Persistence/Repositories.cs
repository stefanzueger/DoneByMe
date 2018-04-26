using DoneByMe.Matching.Model.Proposals;

namespace DoneByMe.Matching.Infra.Persistence
{
    public class Repositories
    {
		private static ProposalRepository proposalRepository;

		public static ProposalRepository ProposalRepository
		{
			get
			{
				if (proposalRepository == null)
				{
					proposalRepository = new JournalProposalRepository();
				}
				return proposalRepository;
			}
		}
		
	}
}
