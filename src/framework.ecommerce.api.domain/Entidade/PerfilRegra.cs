using System;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class PerfilRegra : Entity
    {
        public Guid PerfilId { get; private set; }
        public Perfil Perfil { get; private set; }
        public Guid RegraId { get; private set; }
        public Regra Regra { get; private set; }


        public PerfilRegra()
        {

        }
    }
}
