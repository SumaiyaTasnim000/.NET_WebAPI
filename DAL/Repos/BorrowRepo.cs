using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class BorrowRepo : IRepo<Borrow, int>
    {
        private readonly BooksContext db;

        public BorrowRepo()
        {
            db = new BooksContext();
        }

        public void Add(Borrow borrow)
        {
            db.Borrows.Add(borrow);
            db.SaveChanges();
        }

        public void Create(Borrow borrow)
        {
            db.Borrows.Add(borrow);
            db.SaveChanges();
        }

        public Borrow Get(int id)
        {
            return db.Borrows.Find(id);
        }

        public List<Borrow> Get()
        {
            return db.Borrows.ToList();
        }

        public void Delete(int id)
        {
            var borrow = Get(id);
            db.Borrows.Remove(borrow);
            db.SaveChanges();
        }

        public void Update(Borrow borrow)
        {
            var existingBorrow = Get(borrow.Id);
            db.Entry(existingBorrow).CurrentValues.SetValues(borrow);
            db.SaveChanges();
        }
    }
}
