using framework.ecommerce.auth.domain.Enum;
using System;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Status = Status.Ativo;
        }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Status Status { get; set; }
    }
}
