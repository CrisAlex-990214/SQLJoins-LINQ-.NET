namespace SqlJoins_LinqC_
{
    public class ShopRepo(ShopDbContext context)
    {
        private readonly ShopDbContext context = context;

        public IQueryable<CustomerAddressDto> GetCustomersWithAddress()
        {
            //var innerJoin = from c in context.Customer
            //                join a in context.Address on c.Id equals a.CustomerId
            //                select new CustomerAddressDto { Customer = c.Name, Address = a.StreetAddress };

            var innerJoin = context.Customer.Join(context.Address, c => c.Id, a => a.CustomerId,
                (c, a) => new CustomerAddressDto { Customer = c.Name, Address = a.StreetAddress });

            return innerJoin;
        }

        public IQueryable<CustomerAddressDto> GetCustomers()
        {
            //var leftOuterJoin = from c in context.Customer
            //                    join a in context.Address on c.Id equals a.CustomerId into addresses
            //                    from address in addresses.DefaultIfEmpty()
            //                    select new CustomerAddressDto { Customer = c.Name, Address = address.StreetAddress };

            var leftOuterJoin = context.Customer.GroupJoin(context.Address, c => c.Id, a => a.CustomerId,
                (customer, addresses) => new { customer, addresses = addresses.DefaultIfEmpty() })
                .SelectMany(x => x.addresses,
                (x, a) => new CustomerAddressDto { Customer = x.customer.Name, Address = a.StreetAddress });

            return leftOuterJoin;
        }

        public IQueryable<CustomerAddressDto> GetAddresses()
        {
            //var rightOuterJoin = from a in context.Address
            //                     join c in context.Customer on a.CustomerId equals c.Id into customers
            //                     from customer in customers.DefaultIfEmpty()
            //                     select new CustomerAddressDto { Customer = customer.Name, Address = a.StreetAddress };

            var rightOuterJoin = context.Address.GroupJoin(context.Customer, a => a.CustomerId, c => c.Id,
                (address, customers) => new { address, customers = customers.DefaultIfEmpty() })
                .SelectMany(x => x.customers,
                (x, c) => new CustomerAddressDto { Customer = c.Name, Address = x.address.StreetAddress });

            return rightOuterJoin;
        }

        public IQueryable<CustomerAddressDto> GetCustomersAndAddresses()
        {
            var leftOuterJoin = GetCustomers();
            return leftOuterJoin.Union(GetAddresses());
        }
    }
}
