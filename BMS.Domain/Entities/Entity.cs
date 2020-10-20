using System;

namespace BMS.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }
        public bool Deletado { get; set; }
        
        public Entity()
        {
            Id = Guid.NewGuid();
            Deletado = false;
        }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}