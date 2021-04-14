using ControleDeNivel.Data.Infra;
using ControleDeNivel.Models;
using ControleDeNivel.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleDeNivel.Data
{
    public class DeviceInfoDao
    {
        private readonly Context _context;
        public DeviceInfoDao(Context context)
        {
            this._context = context;
        }
        public Result<List<DeviceInfo>> Get()
        {
            Result<List<DeviceInfo>> result;
            try
            {
                result = new Result<List<DeviceInfo>>();
                result.Value = this._context.DeviceInfos.ToList();
                result.HasError = false;
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
                result = new Result<DeviceInfo>();
                result.Value = this._context.DeviceInfos
                    .Where(b => b.IdDeviceInfo == id)
                    .FirstOrDefault();
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<DeviceInfo>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Set(DeviceInfo data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                this._context.DeviceInfos.Add(data);
                this._context.SaveChanges();
                result.Value = data.IdDeviceInfo;
                result.HasError = false;
            }
            catch (Exception e)
            {
                result = new Result<object>(true, null, e.Message, e.ToString());
            }
            return result;
        }
        public Result<object> Update(DeviceInfo data)
        {
            Result<object> result;
            try
            {
                result = new Result<object>();
                DeviceInfo info = this._context.DeviceInfos
                        .Where(b => b.IdDeviceInfo == data.IdDeviceInfo)
                        .FirstOrDefault();
                data.IdDeviceInfo = info.IdDeviceInfo;
                this._context.DeviceInfos.Update(data);
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
                DeviceInfo info = this._context.DeviceInfos
                        .Where(b => b.IdDeviceInfo == id)
                        .FirstOrDefault();
                this._context.DeviceInfos.Remove(info);
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
