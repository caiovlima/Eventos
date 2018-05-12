using System;
using System.Collections.Generic;
using System.Text;
using Eventos.IO.Domain.Interfaces;

namespace Eventos.IO.Domain.Eventos.Repository
{
    public interface IEventoRepository: IRepository<Evento> //implementa o repo genérico
    {
        IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);
        Endereco ObterEnderecoPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
    }
}
