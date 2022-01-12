using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SelfAspNet.Models
{
    public partial class SelfAspEntityModel : DbContext
    {
        public SelfAspEntityModel()
            : base("name=SelfAspEntityModel")
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
