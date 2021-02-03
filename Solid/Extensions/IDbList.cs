using System.Collections.Generic;

namespace Solid.Extensions
{
    public interface IDbList<T> : IList<T>
    {
        long NextKey();
        T Find(long key);
        void Insert(T item);
        void Insert(IList<T> itens);
        void Update(T item);
    }
}
