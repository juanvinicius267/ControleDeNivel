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
    public class DeviceInfosController : ControllerBase
    {
        private readonly DevicesInfo _context;
        public DeviceInfosController(DevicesInfo context)
        {
            _context = context;
        }
        // GET api/DeviceInfos
        [HttpGet]
        public ActionResult Get()
        {
            Result<List<DeviceInfo>> result;
            result = this._context.Get();
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // GET api/DeviceInfos/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Result<DeviceInfo> result;
            result = this._context.GetById(id);
            if (result.HasError == false)
            {
                return Ok(result.Value);
            }
            return BadRequest(result);
        }

        // POST api/DeviceInfos
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

        // PUT api/DeviceInfos/5
        [HttpPut("{id}")]
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

        // DELETE api/DeviceInfos/5
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