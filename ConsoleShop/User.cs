using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop
{
    class User
    {
        public User(int balance)
        {
            Balance = balance;
        }
        private int _balance;
        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= -10)
                    _balance = value;
                else
                    _balance = -10;
            }
        }
    }
}
