using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(EventoExcluidoEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
