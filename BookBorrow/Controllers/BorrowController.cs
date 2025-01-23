using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBorrow.Controllers
{
    public class BorrowController : ApiController
    {
        [HttpGet]
        [Route("api/borrow/all")]
        public HttpResponseMessage Get()
        {
            var data = BorrowService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/borrow/create")]
        public HttpResponseMessage Create(BorrowDTO s)
        {
            BorrowService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/borrow/update/{id}")]
        public HttpResponseMessage Update(int id, BorrowDTO s)
        {
            s.Id = id;
            BorrowService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/borrow/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            BorrowService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

