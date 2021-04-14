using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleDeNivel.Models
{
    public class SinalDeInputDaPagina
    {
        [Key]
        public int IdSinal { get; set; }
        public int IdDeviceInfo { get; set; }
        public bool I00 { get; set; }//Abrir
        public bool I01 { get; set; }//Parar
        public bool I02 { get; set; }//Fechar
        public bool I03 { get; set; }//Emergencia
        public bool I04 { get; set; }
        public bool I05 { get; set; }
        public bool I06 { get; set; }
        public bool I07 { get; set; }
    }
}
