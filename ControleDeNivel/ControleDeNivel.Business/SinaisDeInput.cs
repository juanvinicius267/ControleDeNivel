using ControleDeNivel.Data;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeNivel.Business
{
    public class SinaisDeInput
    {
        private readonly SinalDeInputDao _context;
        public SinaisDeInput(SinalDeInputDao context)
        {
            this._context = context;
        }
        public Result<List<SinalDeInputDaPagina>> Get()
        {
            Result<List<SinalDeInputDaPagina>> result;
            try
            {
                result = _context.Get();
            }
            catch (Exception e)
            {

                result = new Result<List<SinalDeInputDaPagina>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<SinalDeInputDaPagina> GetById(int id)
        {
            Result<SinalDeInputDaPagina> result;
            try
            {
                result = _context.GetById(id);
            }
            catch (Exception e)
            {

                result = new Result<SinalDeInputDaPagina>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(object data)
        {
            Result<object> result;
            try
            {
                SinalDeInputDaPagina info = JsonConvert.DeserializeObject<SinalDeInputDaPagina>(data.ToString());
                result = _context.Set(info);
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;

        }
        public Result<object> Update(object data)
        {
            Result<object> result;
            try
            {
                SinalDeInputDaPagina info = JsonConvert.DeserializeObject<SinalDeInputDaPagina>(data.ToString());
                result = _context.Update(info);
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Delete(int id)
        {
            Result<object> result;
            try
            {
                result = _context.Delete(id);
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
    }
}
