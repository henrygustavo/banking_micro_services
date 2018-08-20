namespace Customer.Domain.Entity
{
    public class Customer: BaseEntity
    {
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
    }
}
