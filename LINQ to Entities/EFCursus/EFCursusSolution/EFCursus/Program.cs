using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFCursus
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("kost:");
            decimal kost;
            if (decimal.TryParse(Console.ReadLine(), out kost))
            {
                using (var entities = new BankEntities())
                { 
                    var aantalAAngepast = entities.AdministratieveKost(kost);
                   
                   
                    Console.WriteLine("{0} rekening(en) aangepast",aantalAAngepast);
                }
            }
            else
            {
                Console.WriteLine("Tik een getal");
            }
         

        }

       
        
    }
}

