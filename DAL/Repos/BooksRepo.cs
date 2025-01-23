using DAL.EF;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class BooksRepo
    {
        private BooksContext db;

        public BooksRepo()
        {
            db = new BooksContext();
        }

        public void Create(Books book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public List<Books> Get()
        {
            return db.Books.ToList();
        }

        public Books Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Update(Books book)
        {
            var existingBook = Get(book.Id);
            if (existingBook != null)
            {
                db.Entry(existingBook).CurrentValues.SetValues(book);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var existingBook = Get(id);
            if (existingBook != null)
            {
                db.Books.Remove(existingBook);
                db.SaveChanges();
            }
        }

        public List<Books> Search(string title, string author, string genre)
        {
            var query = db.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.Title.Contains(title));

            if (!string.IsNullOrEmpty(author))
                query = query.Where(b => b.Author.Contains(author));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.Genre.Contains(genre));

            return query.ToList();
        }
    }
}
