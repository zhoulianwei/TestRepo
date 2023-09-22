using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer_Server.Requests;
using WebServer_Server.Responses;
using WebServer_Server.Services;

namespace WebServer_Server.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class PeopleController : ControllerBase
    {
        private CatchService _catch { get; }

        public PeopleController(CatchService catchService)
        {
            _catch = catchService;
        }

        [HttpGet]
        public string GetById(int id)
        {
            var result=_catch.GetCachedData(id.ToString());
            Console.WriteLine($"result is : {result}");
            return result;
        }


        [HttpPost]
        public ActionResult GetByRequest([FromBody] PeopleRequest request)
        {
            Console.WriteLine($"request is : {JsonConvert.SerializeObject(request)}");

            var response = new PeopleResponse
            {
                Age = 18,
                Name = "zhangsan"
            };

            return Ok(response);
        }
    }
}
