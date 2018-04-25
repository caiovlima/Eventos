using FluentValidation;
using FluentValidation.Results;
using System;
/*Toda entidade ela vai herdade dessa classe de Entity, então fizemos uma série de operações, onde
 * toda e qualquer entidade vai ter um Id que vai ser comparado e gerar um Id próprio para cada entidade
 
     Outro fato é que essa classe de Entity foi criada justamente para ser uma base para as outras, por isso ela está no Core*/

namespace Eventos.IO.Domain.Core.Models
{
    /*Depois de instalar o FV no meu Domain e Domain.Core, a minha classe de Entity deve implementar uma entidade genérica
     * utilizando o AbstractValidator(classe do FV) que recebe o T da Entidade abstrata que a classe Entity implementa
     * isso serve para que possamos aplicar as regras de auto validação nas classes que implementarão a nossa classe de Entity*/

    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }
        public abstract bool EhValido();
        
        public ValidationResult ValidationResult { get; protected set; } //classe do Fluent Validation, para usar em qualquer outra classe, deve-se gerar um construtor

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);

        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);

        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {

            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }

    }
}

