using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Borrow
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; } 
        public string DateBorrowed { get; set; }
        public string ReturnDate { get; set; }
    }
}
