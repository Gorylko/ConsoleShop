using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities.Enums;

namespace ConsoleShop.Shared.Entities
{
    public class User
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public RoleType Role { get; set; }

        public bool HasRole(RoleType role)
        {
            return Role == role;
        }
    }
}
