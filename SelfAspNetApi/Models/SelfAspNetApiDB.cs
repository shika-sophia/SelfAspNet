using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SelfAspNetApi.Models
{
    public partial class SelfAspDB : DbContext
    {
        public SelfAspDB()
            : base("name=SelfAspNetApiDB")
        {
        }

        public virtual DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.isbn)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
