using System.Collections.Generic;

namespace framework.ecommerce.auth.domain.Entidade
{
    public class Regra : Entity
    {
        public string Tipo { get; private set; }
        public string Valor { get; private set; }
        public bool Ativo { get; private set; }

        //EF Relation
        public ICollection<PerfilRegra> PerfilRegras { get; private set; }

        public Regra()
        {

        }
    }
}
