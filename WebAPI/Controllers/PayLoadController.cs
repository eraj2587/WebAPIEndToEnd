using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //State what type of method are we using while sending the data
    public class PayLoadController : ApiController
    {
        Employee emp;
        public PayLoadController()
        {
            emp = new Employee();
        }

        public IHttpActionResult Get()
        {
            return Ok(emp.GetEmployees());
        }


        public IHttpActionResult Get(int Id)
        {
            var res = emp.GetEmployees().Where(x => x.Id.Equals(Id));

            if (res == null)
            {
                return NotFound();
            };

            return Ok(res);
        }

        /*
        PUT : http://localhost:49701/api/payload?id=5 

        Header : Host: localhost:49701
        Content-Length: 38
        content-type: application/json

        Body: {"Id":1,"Name":"Raj","Address":"Pune"}       
         */

        public IHttpActionResult PutEmployee(int id, [FromBody]Employee e) //by default value types from uri and refernce type from body
        {
            return Ok();
        }
    }
}