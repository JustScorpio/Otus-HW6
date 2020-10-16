using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;
using Otus.Teaching.Pcf.ReceivingFromPartner.DataAccess.Data;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.DataAccess
{
    public class DataContext
        : DbContext
    {

        public DbSet<Partner> Partners { get; set; }

        public DataContext()
        {
            
        }
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}