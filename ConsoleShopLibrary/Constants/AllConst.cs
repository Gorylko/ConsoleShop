using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShopLibrary.Constants
{
    public static class AllConst
    {
        public const string ConnectionString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=MyProjects;Integrated Security=True"; //Change as necessary

        public const int MinLoginSize = 5;

        public const int MinPasswordSize = 5;

        public const string NewLine = "\n";

        public const string NewLineX2 = "\n\n";

        public const string Tab = "\t";

        public const string TabX2 = "\t\t";

        public const ConsoleColor GreenColor = ConsoleColor.Green;

        public const ConsoleColor RedColor = ConsoleColor.Red;

        public const ConsoleColor YellowColor = ConsoleColor.Yellow;

        public const ConsoleColor DefaultColor = ConsoleColor.White;
    }
}
