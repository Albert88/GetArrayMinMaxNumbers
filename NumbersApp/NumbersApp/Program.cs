using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NumbersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();

            numbers.Start();

            // or we can use static method

            // Numbers.StartProgram();
        }
    }
}
