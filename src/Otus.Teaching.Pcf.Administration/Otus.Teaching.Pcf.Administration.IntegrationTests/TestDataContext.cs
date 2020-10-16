using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Pcf.Administration.DataAccess;

namespace Otus.Teaching.Pcf.Administration.IntegrationTests
{
    public class TestDataContext
        : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PromocodeFactoryAdministrationDb.sqlite");
        }
    }
}