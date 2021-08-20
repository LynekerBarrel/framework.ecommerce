
using System;
using System.Collections.Generic;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class Usuario : Entity
    {
        public Guid IdentityId { get; set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Celular { get;  set; }

        public Usuario() : base()
        {

        }

        public Usuario(Guid identityId)
        {
            IdentityId = identityId;
        }
        public Usuario(
            Guid identityId,
            bool contratante,
            string email = null,
            string nome = null,
            string celular = null) : base()
        {
            IdentityId = identityId;
            Email = email;
            Nome = nome;
            Celular = celular;

        }
    }
}
