using System.Collections.Generic;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class Perfil : Entity
    {
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        //EF Relation
        public ICollection<PerfilRegra> PerfilRegras { get; private set; }

        public Perfil()
        {

        }
    }
}
