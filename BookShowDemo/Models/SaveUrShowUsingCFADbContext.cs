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
       /* public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<FindTicket> FindTicket { get; set; }
        public virtual DbSet<BookTicket> BookTicket { get; set; }*/

        public DbSet<Registration> Registration { get; set; }
        public DbSet<FindTicket> FindTicket { get; set; }
        public DbSet<BookTicket> BookTicket { get; set; }

    }
}
