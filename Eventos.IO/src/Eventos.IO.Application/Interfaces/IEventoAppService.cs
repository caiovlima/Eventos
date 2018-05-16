using Eventos.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        void Registrar(EventoViewModel eventoViewModel);
        IEnumerable<EventoViewModel> ObterTodos();
        IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId);
        EventoViewModel ObterPorId(Guid id);
        void Atualizar(EventoViewModel eventoViewModel);
        void Excluir(Guid id);
    }
}
