using System;

namespace backend.Models
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