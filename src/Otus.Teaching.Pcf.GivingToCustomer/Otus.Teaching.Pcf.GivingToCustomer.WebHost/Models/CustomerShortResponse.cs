using System;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Models
{
    public class CustomerShortResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}