using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess;

namespace Otus.Teaching.Pcf.GivingToCustomer.IntegrationTests
{
    public class TestDataContext
        : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PromocodeFactoryGivingToCustomerDb.sqlite");
        }
    }
}