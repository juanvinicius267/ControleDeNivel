using ControleDeNivel.Data.Infra;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeNivel.Data
{
    public class MensagensDao
    {
        private readonly Context _context;
        public MensagensDao(Context context)
        {
            this._context = context;
        }
        public Result<List<Mensagem>> Get()
        {
            Result<List<Mensagem>> result;
            try
            {
                result = new Result<List<Mensagem>>();
                result.Value = this._context.Mensagens.ToList();
                result.HasError = false;
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
                result = new Result<Mensagem>();
                result.Value = this._context.Mensagens
                    .Where(b => b.IdMensagem == id)
                    .FirstOrDefault();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<Mensagem>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(Mensagem data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                this._context.Mensagens.Add(data);
                this._context.SaveChanges();
                result.Value = data.IdMensagem;
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Update(Mensagem data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                Mensagem info = this._context.Mensagens
                        .Where(b => b.IdMensagem == data.IdMensagem)
                        .FirstOrDefault();
                data.IdMensagem = info.IdMensagem;
                this._context.Mensagens.Update(data);
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
                Mensagem info = this._context.Mensagens
                        .Where(b => b.IdMensagem == id)
                        .FirstOrDefault();
                this._context.Mensagens.Remove(info);
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
