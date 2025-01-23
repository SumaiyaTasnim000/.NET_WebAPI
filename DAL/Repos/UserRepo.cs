using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo : IRepo<User, int>
    {
        private readonly BooksContext db;

        public UserRepo()
        {
            db = new BooksContext(); 
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public void Update(User user)
        {
            var existingUser = Get(user.Id);
            db.Entry(existingUser).CurrentValues.SetValues(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
