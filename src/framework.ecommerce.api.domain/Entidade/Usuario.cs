
using System;
using System.Collections.Generic;

namespace framework.ecommerce.api.auth.domain.Entidade
{
    public class Usuario : Entity
    {
        public Guid IdentityId { get; set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Celular { get;  set; }
        //public string Crmv { get;  set; }
        //public string Mapa { get;  set; }
        //public string Cargo { get;  set; }
        //public bool Contratante { get;  set; }

        ////EF Relation
        //public ICollection<ClinicaUsuario> ClinicaUsuarios { get; set; }

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
            string celular = null,
            string crmv = null,
            string mapa = null,
            string cargo = null) : base()
        {
            IdentityId = identityId;
            Email = email;
            Nome = nome;
            Celular = celular;
            //Crmv = crmv;
            //Mapa = mapa;
            //Cargo = cargo;
            //Contratante = contratante;
        }
    }
}
