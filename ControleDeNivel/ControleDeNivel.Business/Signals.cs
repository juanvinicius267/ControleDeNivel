using ControleDeNivel.Data;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeNivel.Business
{
    public class Signals
    {
        private readonly SinaisDao _context;
        public Signals(SinaisDao context)
        {
            this._context = context;
        }
        public Result<List<Sinal>> Get()
        {
            Result<List<Sinal>> result;
            try
            {
                result = _context.Get();
            }
            catch (Exception e)
            {

                result = new Result<List<Sinal>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<Sinal> GetById(int id)
        {
            Result<Sinal> result;
            try
            {
                result = _context.GetById(id);
            }
            catch (Exception e)
            {

                result = new Result<Sinal>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(object data)
        {
            Result<object> result;
            try
            {
                Sinal info = JsonConvert.DeserializeObject<Sinal>(data.ToString());
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
                Sinal info = JsonConvert.DeserializeObject<Sinal>(data.ToString());
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
