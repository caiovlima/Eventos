using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Eventos;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        public Organizador(Guid id, string nome, string cpf, string email)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        protected Organizador() { } //construtor para o ef core

        //EF Propriedade de Navegação
        public virtual ICollection<Evento> Eventos { get; set; }
        public override bool EhValido()
        {
            return true;
        }
    }
}
