using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class BooksContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrow> Borrows { get; set; }


    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>()
                .HasRequired(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Borrow>()
                .HasRequired(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}
