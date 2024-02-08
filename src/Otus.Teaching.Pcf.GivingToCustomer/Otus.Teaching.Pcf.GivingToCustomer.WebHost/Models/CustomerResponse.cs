using System;
using System.Collections.Generic;
using System.Linq;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Models
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> Preferences { get; set; } = new List<Guid>();
        public List<Guid> PromoCodes { get; set; } = new List<Guid>();

        public CustomerResponse()
        {
            
        }

        public CustomerResponse(Customer customer)
        {
            Id = customer.Id;
            Email = customer.Email;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Preferences = customer.Preferences.Select(x =>  x.PreferenceId).ToList();
            PromoCodes = customer.PromoCodes.Select(x => x.PromoCodeId).ToList();
        }
    }
}