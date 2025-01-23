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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

      
        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create([FromBody] UserDTO userDto)
        {
            try
            {
                UserService.Create(userDto);
                return Request.CreateResponse(HttpStatusCode.OK, "User created successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

   
        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] UserDTO userDto)
        {
            try
            {
                userDto.Id = id;
                UserService.Update(userDto);
                return Request.CreateResponse(HttpStatusCode.OK, "User updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        
        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

