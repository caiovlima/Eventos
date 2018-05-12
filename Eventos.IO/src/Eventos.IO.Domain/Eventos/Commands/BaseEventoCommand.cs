using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    //aplicando o conceito de CQRS onde separamos o que vai escrever ou ler um dado ou entidade
    /*criamos uma pasta de command onde nela teremos algumas classes de atualizar, registrar e etcc
     * essa classe em questão Base serve como base para todas as outras, por isso ela é abstract
     * e em suas propriedades setamos apenas como protected, para que as outras classes que irão implementar algo dela
     * possam setar as propriedades no construtor*/
    public abstract class BaseEventoCommand : Command
    {
        public Guid  Id { get; protected set; }
        public string Nome { get; protected set; }
        public string DescricaoCurta { get; protected set; }
        public string DescricaoLonga { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataFim { get; protected set; }
        public bool Gratuito { get; protected set; }
        public decimal Valor { get; protected set; }
        public bool Online { get; protected set; }
        public string NomeEmpresa { get; protected set; }
        public Guid OrganizadorId { get; protected set; }
        public Endereco Endereco{ get; protected set; }
        public Categoria Categoria { get; protected set; }

    }
}

