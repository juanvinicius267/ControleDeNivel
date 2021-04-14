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
    public class SinaisController : ControllerBase
    {
        private readonly Signals _context;
        public SinaisController(Signals context)
        {
            _context = context;
        }
        // GET: api/Sinais
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<Sinal>> result;
            result = this._context.Get();
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // GET: api/Sinais/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Result<Sinal> result;
            result = this._context.GetById(id);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // POST: api/Sinais
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

        // PUT: api/Sinais/5
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
