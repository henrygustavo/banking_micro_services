namespace Common.Domain.Entity
{
    using System;

    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
