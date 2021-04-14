using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeNivel.Business;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeNivel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogFalhasController : ControllerBase
    {
        private readonly LogsFalha _context;
        public LogFalhasController(LogsFalha context)
        {
            _context = context;
        }
        // GET: api/LogFalhas
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<LogFalha>> result;
            result = this._context.Get();
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // GET: api/LogFalhas/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Result<List<LogFalha>> result;
            result = this._context.GetByDate(id);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // POST: api/LogFalhas
        [HttpPost]
        public ActionResult Post([FromBody] object value)
        {
            Result<object> result;
            result = this._context.Set(value);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // PUT: api/LogFalhas/5
        [HttpPut]
        public ActionResult Put([FromBody] object value)
        {
            Result<object> result;
            result = this._context.Update(value);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Result<object> result;
            result = this._context.Delete(id);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }
    }
}
