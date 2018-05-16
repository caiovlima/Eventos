using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>, //implementamos a nossa interface, observe que tem o metodo handle que tem lá no iHandler
        IHandler<AtualizarEventoCommand>,// logo ele implementa também os commando de registrar, atualizar e excluir
        IHandler<ExcluirEventoCommand>
    {

        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;
        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }
        public void Handle(RegistrarEventoCommand message)
        {
            /*ENTENDENDO:
             * Nesse método iremos registrar o evento, construimos toda uma estrutura de Handlers para entender
             * a escrita na base de dados, então o método cria um novo evento(entidade evento) recebendo todos as propriedades
             * que irão escrever no banco, feito isso ele tem um if para validação e logo depois ele escreve com o _eventoRepository
             * esse por sua vez faz parte da injeção de dependencia,onde ele recebe a Interface do IEventoRepository em um método
             * readonly e atribui um nome para ser utilizado _eventoRepository, 
             * logo depois temos um construtor para ele poder entender
             * que iremos utilizar a injeção de dependencia, dizendo que _eventoRepository se equivale ao eventoRepository, 
             * ai na persistencia  você chama a propriedade_eventoRepository passando o Add juntamente com a variável que instancia
             * o objeto Evento.*/
            var endereco = new Endereco(message.Id, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Complemento, message.Endereco.Bairro, message.Endereco.CEP, message.Endereco.Cidade, message.Endereco.Estado, message.Endereco.EventoId.Value);
            var evento = Evento.EventoFactory.NovoEventoCompleto(
                message.Id,
                message.Nome,
                message.DescricaoCurta,
                message.DescricaoLonga,
                message.DataInicio,
                message.DataFim,
                message.Gratuito,
                message.Valor,
                message.Online,
                message.NomeEmpresa,
                message.OrganizadorId,
                endereco,
                message.CategoriaId);
            
            if (!EventoValido(evento)) return;

            // TODO:
            //Validações de negocio
            //Organizador pode registrar evento ?

            //persistencia

            _eventoRepository.Adicionar(evento);

            if(Commit())
            {
                //Notificar processo concluido !
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
                
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var eventoAtual = _eventoRepository.ObterPorId(message.Id);
            if (!EventoExistente(message.Id, message.MessageType)) return;

            // TODO: Validar se o evento pertence a pessoa que está editando.
            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                message.DescricaoLonga, message.DataInicio, message.DataFim, message.Gratuito, message.Valor,
                message.Online, message.NomeEmpresa, message.OrganizadorId, eventoAtual.Endereco, message.CategoriaId);

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType)) return;

            _eventoRepository.Remover(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
            }

        }

        private bool EventoValido(Evento evento)
        {
            if (!evento.EhValido()) return true;
            
            NotificarValidacoesErro(evento.ValidationResult);
            return false;
            
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);
            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado"));
            return false;
        }
    }
}


