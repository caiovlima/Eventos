using Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models
{
    public class Evento : Entity<Evento>
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
            string nomeEmpresa, 
            Categoria categoria,
            Endereco endereco 
                )
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeEmpresa = nomeEmpresa;
            Categoria = categoria;
            Endereco = endereco;

           
           
        }

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
        public string NomeEmpresa { get; private set; }
        public Categoria Categoria { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Endereco Endereco { get; private set; }
        public Organizador Organizador { get; private set; }



      
        //Método que faz override o metodo abstrato da classe que implementamos (entity)
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        //criamos validações específicas para Nome, Valor, Data, Local e Etc.., a partir dela
        // nosso método Validar recebe cada um deles, e dai no nosso método EhValido, iremos utilizar como se fosse 
        //um apanhado de tudo
        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();
            ValidationResult = Validate(this); //aqui dizemos para validar a própria instância do método validar

        }
        
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome deve possuir entre 2 e 150 caracteres");
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(1, 50000)
                    .WithMessage("O valor deve estar entre 1.00 e 50.000");

            if (Gratuito)
                RuleFor(c => c.Valor)
                    .ExclusiveBetween(0, 0).When(e => e.Gratuito)
                    .WithMessage("O Valor não deve ser diferente de 0");
        }

        private void ValidarData()
        {
            RuleFor(c => c.DataInicio)
                .GreaterThan(c => c.DataFim)
                .WithMessage("A data início deve ser maior do que a data final do evento");

            RuleFor(c => c.DataFim)
                .LessThan(DateTime.Now)
                .WithMessage("A data de início não pode ser menor do que a data atual");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(c => c.Endereco)
                    .Null().When(c => c.Online)
                    .WithMessage("O endereço não pode possuir endereço se for online");

            if (!Online)
                RuleFor(c => c.Endereco)
                    .NotNull().When(c => c.Online == false)
                    .WithMessage("O evento deve possuir um endereço");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(c => c.NomeEmpresa)
                .NotEmpty().WithMessage("O nome do organizador precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome da empresa deve possuir entre 2 e 150 caracteres");
        }
        #endregion
    }

    //Começar aula 11
}
