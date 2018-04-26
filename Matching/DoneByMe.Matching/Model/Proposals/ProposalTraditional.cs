using System;
using System.Collections.Generic;
using System.Text;

namespace DoneByMe.Matching.Model.Proposals
{
    class ProposalTraditional
    {
        public Id Id { get; }
        public Client Client { get; }
        public Expectations Expectations { get; }
        public Progress Progress { get; }

        public static ProposalTraditional SubmitFor(Client client, Expectations expectations)
        {
            return new ProposalTraditional(Id.Unique(), client, expectations);
        }
        private ProposalTraditional(Id id, Client client, Expectations expectations)
        {
            this.Id = id;
            this.Client = client;
            this.Expectations = expectations;
            this.Progress = Progress.NONE;
        }
    }
}
