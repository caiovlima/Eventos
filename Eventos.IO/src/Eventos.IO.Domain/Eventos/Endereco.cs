using Eventos.IO.Domain.Core.Models;
using System;
using FluentValidation;

namespace Eventos.IO.Domain.Eventos
{
    public class Endereco : Entity<Endereco>
    {
        
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        //chave de relacionamento
        public Guid? EventoId { get; private set; }
        //propriedade de navegação
        public virtual Evento Evento { get; private set; }

        //Construtor vazio que o EF Core exige
        protected Endereco()
        {

        }

        public Endereco(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid? eventoId)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
           
        }

        public override bool EhValido()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O logradouro precisa ser fornecido")
                .Length(2, 150).WithMessage("O logradouro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O Bairro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Bairro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O CEP precisa ser fornecido")
                .Length(8).WithMessage("O CEP precisa ter 8 caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A Cidade precisa ser fornecida")
                .Length(2, 150).WithMessage("A Cidade precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O estado precisa ser fornecido")
                .Length(2, 150).WithMessage("O estado precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O numero precisa ser fornecido")
                .Length(1, 10).WithMessage("O numero precisa ter entre 1 e 10 caracteres");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;

            
        }
    }
}