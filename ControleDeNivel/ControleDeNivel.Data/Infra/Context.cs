using ControleDeNivel.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ControleDeNivel.Data.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
         : base(options)
        {
        }


        public DbSet<DeviceInfo> DeviceInfos { get; set; }
        public DbSet<LogFalha> LogFalhas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Sinal> Sinais { get; set; }
        public DbSet<SinalDeInputDaPagina> SinaisDeInputDaPagina { get; set; }
    }
}
