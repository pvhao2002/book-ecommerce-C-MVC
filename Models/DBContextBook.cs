using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineBookShop.Models
{
    public partial class DBContextBook : DbContext
    {
        public DBContextBook()
            : base("name=DBContextBookConnectString")
        {
        }

        public virtual DbSet<books> books { get; set; }
        public virtual DbSet<order_item> order_item { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<books>()
                .HasMany(e => e.order_item)
                .WithOptional(e => e.books)
                .HasForeignKey(e => e.idBook);

            modelBuilder.Entity<users>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.idUser);
        }
    }
}
