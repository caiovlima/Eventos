using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Models
{
    public class Evento : Entity
    {
        public Evento(
            string nome, 
            string descricaoCurta, 
            string descricaoLonga, 
            DateTime dataInicio, 
            DateTime dataFim, 
            bool gratuito, 
            decimal valor,
            bool online, 
            string nomeDaEmpresa, 
            Categoria categoria, 
            ICollection<Tags> tags, 
            Endereco endereco, 
            Organizador organizador)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;
            Categoria = categoria;
            Tags = tags;
            Endereco = endereco;
            Organizador = organizador;
        }

        //Aula 10 | 01:00:00

        //Como eu estou protegendo minhas entidades com private set, há uma necessidade de usar um ctor para outras entidades 
        //referenciarem minha classe de evento, se necessário !
        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeDaEmpresa { get; private set; }
        public Categoria Categoria { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Endereco Endereco { get; private set; }
        public Organizador Organizador { get; private set; }

    }


}
