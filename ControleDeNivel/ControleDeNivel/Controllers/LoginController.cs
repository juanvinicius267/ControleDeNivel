using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeNivel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly DevicesInfo _context;
        //public LoginController(DevicesInfo context)
        //{
        //    context = _context;
        //}
        // GET api/Login
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Login/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/Login
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Login/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
