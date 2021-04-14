using ControleDeNivel.Data.Infra;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeNivel.Data
{
    public class LogFalhasDao
    {
        private readonly Context _context;
        public LogFalhasDao(Context context)
        {
            this._context = context;
        }
        public Result<List<LogFalha>> Get()
        {
            Result<List<LogFalha>> result;
            try
            {
                result = new Result<List<LogFalha>>();
                result.Value = this._context.LogFalhas.ToList();
                result.HasError = false;
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
                result = new Result<LogFalha>();
                result.Value = this._context.LogFalhas
                    .Where(b => b.IdLogFalhas == id)
                    .FirstOrDefault();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<LogFalha>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<List<LogFalha>> GetByDate(DateTime data)
        {
            Result<List<LogFalha>> result;
            try
            {
                result = new Result<List<LogFalha>>();
                result.Value = this._context.LogFalhas
                    .Where(b => b.RecordDate.Date == data.Date)
                    .ToList();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<List<LogFalha>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(LogFalha data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                this._context.LogFalhas.Add(data);
                this._context.SaveChanges();
                result.Value = data.IdLogFalhas;
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Update(LogFalha data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                LogFalha info = this._context.LogFalhas
                        .Where(b => b.IdLogFalhas == data.IdLogFalhas)
                        .FirstOrDefault();
                data.IdLogFalhas = info.IdLogFalhas;
                this._context.LogFalhas.Update(data);
                result.Value = this._context.SaveChanges();
                result.HasError = false;
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
                result = new Result<object>();
                LogFalha info = this._context.LogFalhas
                        .Where(b => b.IdLogFalhas == id)
                        .FirstOrDefault();
                this._context.LogFalhas.Remove(info);
                result.Value = this._context.SaveChanges();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
    }
}
