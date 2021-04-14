using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleDeNivel.Models
{
    public class LogFalha
    {
        [Key]
        public int IdLogFalhas { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
