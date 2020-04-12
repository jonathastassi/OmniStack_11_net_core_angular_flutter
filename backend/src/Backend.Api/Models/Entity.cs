using System;

namespace Backend.Api.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            CreateDate = DateTime.Now;
        }

        public DateTime CreateDate { get; private set; }
    }
}