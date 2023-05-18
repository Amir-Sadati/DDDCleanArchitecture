using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
    {
        protected Entity() 
        { 
        }
        protected Entity(TId id)
        {
            Id = id;
        }
        private readonly List<IDomainEvent> _domainEvents = new();

        public TId Id { get; protected set; }

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

    }
}
