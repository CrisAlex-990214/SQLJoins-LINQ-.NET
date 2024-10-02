namespace SqlJoins_LinqC_.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
