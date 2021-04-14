using ControleDeNivel.Data;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeNivel.Business
{
    public class LogsFalha
    {
        private readonly LogFalhasDao _context;
        public LogsFalha(LogFalhasDao context)
        {
            this._context = context;
        }
        public Result<List<LogFalha>> Get()
        {
            Result<List<LogFalha>> result;
            try
            {
                result = _context.Get();
            }
            catch (Exception e)
            {

                result = new Result<List<LogFalha>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<LogFalha> GetById(int id)
        {
            Result<LogFalha> result;
            try
            {
                result = _context.GetById(id);
            }
            catch (Exception e)
            {

                result = new Result<LogFalha>(true, null, e.Message, e.ToString());
            }
            return result;
        }//
        public Result<List<LogFalha>> GetByDate(string date)
        {
            Result<List<LogFalha>> result;
            try
            {
                DateTime data = Convert.ToDateTime(date);
                result = _context.GetByDate(data);
            }
            catch (Exception e)
            {

                result = new Result<List<LogFalha>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(object data)
        {
            Result<object> result;
            try
            {
                LogFalha info = JsonConvert.DeserializeObject<LogFalha>(data.ToString());
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
                LogFalha info = JsonConvert.DeserializeObject<LogFalha>(data.ToString());
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
