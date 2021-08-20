using Microsoft.AspNetCore.Identity;
using System;

namespace framework.ecommerce.auth.Models
{
    /// <summary>
    /// Usuario
    /// </summary>
    public class Usuario : IdentityUser
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public Usuario()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
    }
}
