﻿using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Eventos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, RegistrarEventoCommand>()
                .ConstructUsing(c => new RegistrarEventoCommand(c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DataFim, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId,
                    new IncluirEnderecoEventoCommand(c.Endereco.Id, c.Endereco.Logradouro, c.Endereco.Numero, c.Endereco.Complemento, c.Endereco.Bairro, c.Endereco.CEP, c.Endereco.Cidade, c.Endereco.Estado, c.Id)));

            CreateMap<EventoViewModel, AtualizarEventoCommand>()
                .ConstructUsing(c => new AtualizarEventoCommand(c.Id, c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DataFim, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId));

            CreateMap<EventoViewModel, ExcluirEventoCommand>()
                .ConstructUsing(c => new ExcluirEventoCommand(c.Id));
        }
    }
}
