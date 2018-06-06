using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Organizadores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Eventos.IO.Infra.Data.Mappings;
using Eventos.IO.Infra.Data.Extensions;

namespace Eventos.IO.Infra.Data.Context
{
    public class EventosContext : DbContext // classe de contexto que o EF vai fazer as tabelas, ela hera de DBContext
    {
        //tabelas que o EF irá fazer
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        //método que o EF Core vai ler para criar, aqui descrevemos as propriedades que cada tabela irá ter
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.AddConfiguration(new EventoMapping());
            modelBuilder.AddConfiguration(new OrganizadorMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new CategoriaMapping());


            base.OnModelCreating(modelBuilder);
        }

        //para o método abaixo, devo instalar os pacotes Microsoft.Extensions
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //string de conexão, devo adicionar um arquivo "appsettings.json" para declarar ela
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
