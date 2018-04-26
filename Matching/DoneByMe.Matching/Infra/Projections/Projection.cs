using System;
using VaughnVernon.Mockroservices;

namespace DoneByMe.Matching.Infra.Projections
{
    public abstract class Projection
    {
		protected DomainEvent ToEvent<T>(Message message) where T : DomainEvent
		{
            Type eventType = Type.GetType(message.Type);
            DomainEvent domainEvent = (DomainEvent) Serialization.Deserialize(message.Payload, eventType);
			return domainEvent;
		}
	}
}
