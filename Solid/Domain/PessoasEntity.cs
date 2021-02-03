using System;

namespace Solid.Domain
{
    public class PessoasEntity : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento {get;set;}
    }
}
