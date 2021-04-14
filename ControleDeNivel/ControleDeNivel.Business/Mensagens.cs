using ControleDeNivel.Data;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeNivel.Business
{
    public class Mensagens
    {
        private readonly MensagensDao _context;
        public Mensagens(MensagensDao context)
        {
            this._context = context;
        }
        public Result<List<Mensagem>> Get()
        {
            Result<List<Mensagem>> result;
            try
            {
                result = _context.Get();
            }
            catch (Exception e)
            {

                result = new Result<List<Mensagem>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<Mensagem> GetById(int id)
        {
            Result<Mensagem> result;
            try
            {
                result = _context.GetById(id);
            }
            catch (Exception e)
            {

                result = new Result<Mensagem>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(object data)
        {
            Result<object> result;
            try
            {
                Mensagem info = JsonConvert.DeserializeObject<Mensagem>(data.ToString());
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
                Mensagem info = JsonConvert.DeserializeObject<Mensagem>(data.ToString());
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
