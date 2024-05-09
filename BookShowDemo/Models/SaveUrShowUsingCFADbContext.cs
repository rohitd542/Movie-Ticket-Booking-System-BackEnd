using SaveUrShowUsingCFA.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.models
{
    public class SaveUrShowUsingCFADbContext : DbContext
    {
        public SaveUrShowUsingCFADbContext(DbContextOptions<SaveUrShowUsingCFADbContext> options)
           : base(options)
        {

        }
 
        public DbSet<Registration> Registration { get; set; }
        public DbSet<FindTicket> FindTicket { get; set; }
        public DbSet<BookTicket> BookTicket { get; set; }

        //Default Customer
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .Property(b => b.usertype)
                .HasDefaultValue("Customer");
        }

    }
}
