using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleDeNivel.Models
{
    public class Sinal
    {
        [Key]
        public int IdSinal { get; set; }
        public int IdDeviceInfo { get; set; }
        public DeviceInfo DeviceInfo { get; set; }
        public bool I00 { get; set; } //Falha
        public bool I01 { get; set; }//Abrindo
        public bool I02 { get; set; }//Aberto
        public bool I03 { get; set; }//Parado
        public bool I04 { get; set; }//Fechando
        public bool I05 { get; set; }//Fechado
        public bool I06 { get; set; }
        public bool I07 { get; set; }
        public bool Q00 { get; set; }//Motor ON
        public bool Q01 { get; set; }//Motor OFF
        public bool Q02 { get; set; }//Valvula Ok
        public bool Q03 { get; set; }//Valvula Problem
        public bool Q04 { get; set; }//Temp Ok.
        public bool Q05 { get; set; }//Temp Problem.
        public bool Q06 { get; set; }
        public bool Q07 { get; set; }
        public int MessagemNum { get; set; }
        public double Temperatura { get; set; }
        public DateTime DataDeAtualizacao { get; set; }

    }
}
