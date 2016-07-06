using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdoGemeenschap
{
    public class RekeningenManager
    {
        public Int32 SaldoBonus()
        {
            var dbmanager = new BankDbManager();
            using (var conBank = dbmanager.GeConnection())
            {
                using (var comBonus = conBank.CreateCommand())
                {
                    comBonus.CommandType = CommandType.Text;
                    comBonus.CommandText = "update Rekeningen set Saldo=Saldo*1.1";
                    conBank.Open();
                    return comBonus.ExecuteNonQuery();
                }
            }

        }
    }
}
