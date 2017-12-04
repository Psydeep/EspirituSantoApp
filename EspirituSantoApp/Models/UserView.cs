using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EspirituSantoApp.Models
{
    public class UserView
    {
        public string UserId { get; set; } //el id es un token

        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

                // para mostrar los titulos de forma correcta en la vista
        public RoleView Role { get; set; }

        public List<RoleView> Roles { get; set; }
    }
}