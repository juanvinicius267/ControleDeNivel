using ControleDeNivel.Data.Infra;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeNivel.Data
{
    public class SinaisDao
    {
        private readonly Context _context;
        public SinaisDao(Context context)
        {
            this._context = context;
        }
        public Result<List<Sinal>> Get()
        {
            Result<List<Sinal>> result;
            try
            {
                result = new Result<List<Sinal>>();
                result.Value = this._context.Sinais.ToList();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<List<Sinal>>(true,null,e.Message,e.ToString());                
            }
            return result;
        }
        public Result<Sinal> GetById(int id)
        {
            Result<Sinal> result;
            try
            {
                result = new Result<Sinal>();
                result.Value = this._context.Sinais
                    .Where(b => b.IdDeviceInfo == id)
                    .FirstOrDefault();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<Sinal>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(Sinal data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                this._context.Sinais.Add(data);
                this._context.SaveChanges();
                result.Value = data.IdSinal;
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Update(Sinal data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                Sinal info = this._context.Sinais
                        .Where(b => b.IdDeviceInfo == data.IdSinal)
                        .FirstOrDefault();                
                data.IdSinal = info.IdSinal;
                this._context.Sinais.Update(data);
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
                Sinal info = this._context.Sinais
                        .Where(b => b.IdDeviceInfo == id)
                        .FirstOrDefault();                
                this._context.Sinais.Remove(info);
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
