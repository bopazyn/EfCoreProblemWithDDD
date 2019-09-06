using System;
using System.Collections.Generic;

namespace EfCoreProblemWithDDD
{
    public abstract class Entity
    {
        public Int32 Id { get; protected set; }

        public override Boolean Equals(Object obj)
        {
            if (!(obj is Entity other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            var comparer = Comparer<Int32>.Default;
            if (comparer.Compare(Id, default) == 0 || comparer.Compare(other.Id, default) == 0)
            {
                return false;
            }

            return comparer.Compare(Id, other.Id) == 0;
        }

        public static Boolean operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static Boolean operator !=(Entity a, Entity b) => !(a == b);

        public override Int32 GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}