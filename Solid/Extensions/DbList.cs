using Solid.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Solid.Extensions
{
    public class DbList<T> : List<T>, IDbList<T> where T : BaseEntity
    {
        public long NextKey()
        {
            T item = this.OrderByDescending(p => p.Codigo).FirstOrDefault();
            if (item == null)
                return 1;
            else
                return item.Codigo + 1;
        }

        public virtual T Find(long key)
        {
            return this.FirstOrDefault(p => p.Codigo == key);
        }

        public virtual void Insert(T item)
        {
            Add(item);
        }

        public virtual void Insert(IList<T> itens)
        {
            AddRange(itens);
        }

        public virtual void Update(T item)
        {
            var fornEntity = this.FirstOrDefault(p => p.Codigo == item.Codigo);
            var index = IndexOf(fornEntity);
            if (index >= 0)
                this[index] = item;
        }
    }
}
