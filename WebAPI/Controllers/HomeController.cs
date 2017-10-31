using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebAPI.Models;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [System.Web.Http.Authorize]
    public class HomeController : ApiController
    {
        Employee emp;

        public HomeController()
        {
            emp = new Employee();
        }

        public IHttpActionResult Get()
        {
            return Ok(emp.GetEmployees());
        }

        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage r = Request.CreateResponse(System.Net.HttpStatusCode.OK, GetEmployees());
        //    //add cache control
        //    r.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20),
        //    };
        //    //add custom headers
        //    r.Headers.Add("Id", DateTime.Now.Ticks.ToString());
        //    return r;
        //}

        //public IHttpActionResult Get()
        //{
        //    return new CustomResult(Content(HttpStatusCode.OK, GetEmployees()),
        //        res => {
        //            res.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
        //            {
        //                MaxAge = TimeSpan.FromMinutes(20),
        //            };
        //            res.Headers.Add("Id", DateTime.Now.Ticks.ToString());
        //        }
        //        );
        //}

        //public Task<IHttpActionResult> Get()
        //{
        //    var response = new CustomResult(Content(HttpStatusCode.OK, GetEmployees()),
        //        res =>
        //        {
        //            res.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
        //            {
        //                MaxAge = TimeSpan.FromMinutes(20),
        //            };
        //            res.Headers.Add("Id", DateTime.Now.Ticks.ToString());
        //        }
        //        );

        //    return Task.FromResult<IHttpActionResult>(response);
        //}

        //public async Task<IHttpActionResult> Get()
        //{
        //    return await GetResult();
        //}


        public IHttpActionResult Get(int Id)
        {
            var res = emp.GetEmployees().Where(x => x.Id.Equals(Id));

            if (res == null)
            {
                return NotFound();
            };

            return Ok(res);
        }

        [System.Web.Http.NonAction]
        public async Task<CustomResult> GetResult()
        {
            return await Task.Run(()=> new CustomResult(Content(HttpStatusCode.OK, emp.GetEmployees()),
                res =>
                {
                    res.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromMinutes(20),
                    };
                    res.Headers.Add("Id", DateTime.Now.Ticks.ToString());
                }
                ));
        }

        
        


    }

    
}
