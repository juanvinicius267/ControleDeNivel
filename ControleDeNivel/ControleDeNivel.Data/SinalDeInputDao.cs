using ControleDeNivel.Data.Infra;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeNivel.Data
{
    public class SinalDeInputDao
    {
        private readonly Context _context;
        public SinalDeInputDao(Context context)
        {
            this._context = context;
        }
        public Result<List<SinalDeInputDaPagina>> Get()
        {
            Result<List<SinalDeInputDaPagina>> result;
            try
            {
                result = new Result<List<SinalDeInputDaPagina>>();
                result.Value = this._context.SinaisDeInputDaPagina.ToList();
                result.HasError = false;
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
                result = new Result<SinalDeInputDaPagina>();
                result.Value = this._context.SinaisDeInputDaPagina
                    .Where(b => b.IdDeviceInfo == id)
                    .FirstOrDefault();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<SinalDeInputDaPagina>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(SinalDeInputDaPagina data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                this._context.SinaisDeInputDaPagina.Add(data);
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
        public Result<object> Update(SinalDeInputDaPagina data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                SinalDeInputDaPagina info = this._context.SinaisDeInputDaPagina
                        .Where(b => b.IdDeviceInfo == data.IdDeviceInfo)
                        .FirstOrDefault();                
                info.I00 = data.I00;
                info.I01 = data.I01;
                info.I02 = data.I02;
                info.I03 = data.I03;
                info.I04 = data.I04;
                info.I05 = data.I05;
                info.I06 = data.I06;
                info.I07 = data.I07;
                this._context.SinaisDeInputDaPagina.Update(info);
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
                SinalDeInputDaPagina info = this._context.SinaisDeInputDaPagina
                        .Where(b => b.IdDeviceInfo == id)
                        .FirstOrDefault();
                this._context.SinaisDeInputDaPagina.Remove(info);
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
