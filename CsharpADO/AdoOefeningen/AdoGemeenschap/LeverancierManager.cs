using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class LeverancierManager
    {
        public void LeveranciersToevoegen(Leverancier eenLeverancier)
        {
            
            var dbmanager= new TuincentrumDbManager();
            using (var conTuin = dbmanager.GetConnection())
            {
                using (var comToevoegen = conTuin.CreateCommand())
                {
                    comToevoegen.CommandType=CommandType.StoredProcedure;
                    comToevoegen.CommandText = "LeveranciersToevoegen";

                    DbParameter parNaam = comToevoegen.CreateParameter();
                    parNaam.ParameterName = "@Naam";
                    parNaam.Value = eenLeverancier.Naam;
                    comToevoegen.Parameters.Add(parNaam);

                    DbParameter parAdres = comToevoegen.CreateParameter();
                    parAdres.ParameterName = "@Adres";
                    parAdres.Value = eenLeverancier.Adres;
                    comToevoegen.Parameters.Add(parAdres);

                    DbParameter parPostcode = comToevoegen.CreateParameter();
                    parPostcode.ParameterName = "@PostNr";
                    parPostcode.Value = eenLeverancier.Postcode;
                    comToevoegen.Parameters.Add(parPostcode);

                    DbParameter parPlaats = comToevoegen.CreateParameter();
                    parPlaats.ParameterName = "@Woonplaats";
                    parPlaats.Value = eenLeverancier.Woonplaats;
                    comToevoegen.Parameters.Add(parPlaats);
                    conTuin.Open();
                    comToevoegen.ExecuteNonQuery();
                }
            }
        }
    }
}
