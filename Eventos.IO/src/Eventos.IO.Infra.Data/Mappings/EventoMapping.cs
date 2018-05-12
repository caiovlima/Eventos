using Eventos.IO.Domain.Eventos;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class EventoMapping : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.NomeEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();

            //acima foram as tabelas que queremos, agora no ignore iremos descartar algumas propriedades
            //para que o EF não entenda que seja uma propriedade da tabela 
                builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.Tags);

            builder.Ignore(e => e.CascadeMode);

            //aqui dizemos que a tabela de Eventos irá ter o nome de Eventos, se não o  EF vai colocar EventOES
            builder.ToTable("Eventos");

            //modelando o relacionamento de evento e organizador, aqui dizemos que um Evento pode ter vários orzanigadores
            builder.HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId); //aqui eu digo que a tabela de eventos possui a FK da tabela de Organizador


            //Modelando relacionamento de Eventos com Categoria
            builder.HasOne(e => e.Categoria)
                .WithMany(e => e.Eventos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false); //aqui eu digo que categoria não é um relacionamento obrigatório, isso só funciona pq o CategoriaId é um Guid null, se não fosse null eu não poderia usar


        }
    }
}
