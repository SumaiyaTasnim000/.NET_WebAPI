using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BorrowDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; } 
        public int UserId { get; set; }
        public string UserName { get; set; } 
        public string DateBorrowed { get; set; }
        public string ReturnDate { get; set; }
    }
}
