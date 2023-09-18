using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer_Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeolpeController : ControllerBase
    {
        [HttpGet]
        public string GetById(int id)
        {
            Console.WriteLine($"id is : {id}");
            return "abc";
        }
    }
}
