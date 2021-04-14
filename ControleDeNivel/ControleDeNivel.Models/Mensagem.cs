using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleDeNivel.Models
{
    public class Mensagem
    {
        [Key]
        public int IdMensagem { get; set; }
        public int Tipo { get; set; }
        public string Descrição { get; set; }
    }
}
