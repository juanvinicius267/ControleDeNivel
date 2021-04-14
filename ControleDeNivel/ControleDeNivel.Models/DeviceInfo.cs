using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace ControleDeNivel.Models
{
    public class DeviceInfo
    {
        [Key]
        public int IdDeviceInfo { get; set; }
        public string Name { get; set; }
        public string GuildCode { get; set; }
        public string IpAdress { get; set; }
        public string Descricao { get; set; }

    }
}
