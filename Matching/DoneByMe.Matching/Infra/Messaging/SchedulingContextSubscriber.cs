using System;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Messaging
{
    public class SchedulingContextSubscriber : ISubscriber
	{
		private static SchedulingContextSubscriber instance;

		private Topic schedulingTopic;
  
		public static SchedulingContextSubscriber Start()
		{
			if (instance == null)
			{
				instance = new SchedulingContextSubscriber();
			}
			return instance;
		}

		public void Handle(Message message)
		{
			if (message.Type.Contains("SchedulingVerified"))
			{
				MessageExchangeReader reader = MessageExchangeReader.From(message);
				string proposalId = reader.PayloadStringValue("originatorId");

				API.ProposalCommands.VerifyScheduling(proposalId);

			}
			else if (message.Type.Contains("SchedulingRejected"))
			{
				MessageExchangeReader reader = MessageExchangeReader.From(message);
				string proposalId = reader.PayloadStringValue("originatorId");
				long suggestedCompletedBy = reader.PayloadLongValue("suggestedCompletedBy");

				API.ProposalCommands.DenyScheduling(proposalId, new DateTime(suggestedCompletedBy));
			}
		}

		private SchedulingContextSubscriber()
		{
			MessageBus messageBus = MessageBus.Start("donebyme");
			this.schedulingTopic = messageBus.OpenTopic("scheduling");

			schedulingTopic.Subscribe(this);
		}
	}
}
