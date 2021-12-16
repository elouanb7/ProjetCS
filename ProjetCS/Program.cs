using Raminagrobis;
using System;
using System.Collections.Generic;

namespace ProjetCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new FournisseurService();
            var test = service.GetAll();
            var str = string.Join(",", test);
            Console.WriteLine($"Fournisseur : {str}");
        }
    }
}
