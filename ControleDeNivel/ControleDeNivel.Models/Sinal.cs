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
        public bool Q10 { get; set; } //Falha
        public bool Q11 { get; set; }//Abrindo
        public bool Q12 { get; set; }//Aberto
        public bool Q13 { get; set; }//Parado
        public bool Q14 { get; set; }//Fechando
        public bool Q15 { get; set; }//Fechado
        public bool Q16 { get; set; }
        public bool Q17 { get; set; }
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
