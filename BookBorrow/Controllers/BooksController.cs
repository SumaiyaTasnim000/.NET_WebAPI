using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBorrow.Controllers
{
    public class BooksController : ApiController
    {
        [HttpGet]
        [Route("api/books/all")]
        public HttpResponseMessage Get()
        {
            var data = BooksService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/books/create")]
        public HttpResponseMessage Create(BooksDTO s)
        {
            BooksService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/books/update/{id}")]
        public HttpResponseMessage Update(int id, BooksDTO s)
        {
            s.Id = id; // Ensure the DTO has the correct ID
            BooksService.Update(s); // Using parameter 's'
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/books/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            BooksService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/books/search")]
        public HttpResponseMessage Search(string title = "", string author = "", string genre = "")
        {
            var data = BooksService.Search(title, author, genre);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
      

    }
}
