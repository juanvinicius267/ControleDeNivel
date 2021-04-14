using ControleDeNivel.Data;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ControleDeNivel.Business
{
    public class DevicesInfo
    {
        private readonly DeviceInfoDao _context;
        public DevicesInfo(DeviceInfoDao context)
        {
            this._context = context;
        }
        public Result<List<DeviceInfo>> Get()
        {
            Result<List<DeviceInfo>> result;
            try
            {
                result = _context.Get();
            }
            catch (Exception e)
            {

                result = new Result<List<DeviceInfo>>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<DeviceInfo> GetById(int id)
        {
            Result<DeviceInfo> result;
            try
            {
                result = _context.GetById(id);
            }
            catch (Exception e)
            {

                result = new Result<DeviceInfo>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(object data)
        {
            Result<object> result;
            try
            {
                DeviceInfo info = JsonConvert.DeserializeObject<DeviceInfo>(data.ToString());
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
                DeviceInfo info = JsonConvert.DeserializeObject<DeviceInfo>(data.ToString());
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
