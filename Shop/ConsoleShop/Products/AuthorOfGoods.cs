using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Products
{
    public class AuthorOfGoods
    {
        public AuthorOfGoods(int id, string name, string phonenumber, string email)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phonenumber;
            this.Email = email;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
