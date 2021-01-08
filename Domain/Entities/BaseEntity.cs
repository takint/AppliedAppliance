using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Base Entity that all other entities should inherit from. A base entity is also an <see cref="AuditableEntity"/> and an <see cref="IHasDomainEvent"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class BaseEntity<TKey> : AuditableEntity, IHasDomainEvent
    {
        [Key]
        public TKey Id { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
