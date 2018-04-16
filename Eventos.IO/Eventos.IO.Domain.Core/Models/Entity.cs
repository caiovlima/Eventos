using System;
/*Toda entidade ela vai herdade dessa classe de Entity, então fizemos uma série de operações, onde
 * toda e qualquer entidade vai ter um Id que vai ser comparado e gerar um Id próprio para cada entidade
 
     Outro fato é que essa classe de Entity foi criada justamente para ser uma base para as outras, por isso ela está no Core*/

namespace Eventos.IO.Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);

        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);

        }

        public static bool operator !=(Entity a, Entity b)
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

