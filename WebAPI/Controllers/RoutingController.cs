using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //with route prefix
    [System.Web.Http.RoutePrefix("emp")]
    public class RoutingController : ApiController
    {
        Employee emp;
        public RoutingController()
        {
            emp = new Employee();
        }

        //route : http://localhost:49701/emp/getdata --valid 200
        [System.Web.Http.Route("getdata")]
        public IHttpActionResult Get()
        {
            return Ok(emp.GetEmployees());
        }
       
        //route : http://localhost:49701/emp/getdata/5 --valid 200
        //route : http://localhost:49701/emp/getdata/6 --invalid 404
        [System.Web.Http.Route("getdata/{Id:min(1):max(5)}")]  //contraint in parameter range(1,3)
        public IHttpActionResult Get(int Id)
        {
            var res = emp.GetEmployees().Where(x => x.Id.Equals(Id));

            if (res == null)
            {
                return NotFound();
            };

            return Ok(res);
        }


        //route : http://localhost:49701/emp/getdata/s --valid
        [System.Web.Http.Route("getdata/{name:alpha}")] //routing contraint, alpha-string
        public IHttpActionResult GetByName(string name)
        {
            var res = emp.GetEmployees().Where(x => x.Name.StartsWith(name));

            if (res == null)
            {
                return NotFound();
            };

            return Ok(res);
        }


        //attribute routing without route prefix at controller level

        //[System.Web.Http.Route("emp/getdata")]
        //public IHttpActionResult Get()
        //{
        //    return Ok(emp.GetEmployees());
        //}

        //route : http://localhost:49701/emp/getdata/5
        //[System.Web.Http.Route("emp/getdata/{Id}")]
        //public IHttpActionResult Get(int Id)
        //{
        //    var res = emp.GetEmployees().Where(x => x.Id.Equals(Id));

        //    if (res == null)
        //    {
        //        return NotFound();
        //    };

        //    return Ok(res);
        //}
    }
}