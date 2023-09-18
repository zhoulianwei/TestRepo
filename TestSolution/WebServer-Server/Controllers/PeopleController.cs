using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer_Server.Services;

namespace WebServer_Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
    }
}
