using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventos.IO.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) : base(context)
        {

        }
        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Endereco.Add(endereco);

        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Endereco.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return Db.Endereco.Find(id);
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return Db.Eventos.Where(e => e.OrganizadorId == organizadorId);
        }

        public override Evento ObterPorId(Guid id)
        {
            return Db.Eventos.Include(e => e.Endereco).FirstOrDefault(e => e.Id == id);
        }
    }
}
