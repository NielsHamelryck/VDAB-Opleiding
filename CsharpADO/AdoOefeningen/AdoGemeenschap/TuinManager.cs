using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace AdoGemeenschap
{
    public class TuinManager
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

        public Int32 EindejaarsKorting()
        {
            var manager = new TuincentrumDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comKorting = conTuin.CreateCommand())
                {
                    comKorting.CommandType = CommandType.StoredProcedure;
                    comKorting.CommandText = "Eindejaarskorting";
                    conTuin.Open();
                    return comKorting.ExecuteNonQuery();
                    
                }
            }
        }

        public void VervangLeverancier()
        {
            var manager = new TuincentrumDbManager();
            using (var conTuin = manager.GetConnection())
            {
                conTuin.Open();
                using (var traVervangen = conTuin.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var comVervang = conTuin.CreateCommand())
                    {
                        comVervang.Transaction = traVervangen;
                        comVervang.CommandType= CommandType.StoredProcedure;
                        comVervang.CommandText = "VervangLevNr2doorLevNr3";
                        if (comVervang.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("er bestaat geen Leverancier 2");
                        }
                    }
                    using (var comDeleteLevnr = conTuin.CreateCommand())
                    {
                        comDeleteLevnr.Transaction = traVervangen;
                        comDeleteLevnr.CommandType=CommandType.StoredProcedure;
                        comDeleteLevnr.CommandText = "DeleteLevnr2";
                        if (comDeleteLevnr.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("er bestaat geen Leverancier 2");
                        }
                    }
                    traVervangen.Commit();
                }
            }
        }

        public Decimal ToonGemiddeldePrijs(String soort)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comToonGemPrijs = conTuin.CreateCommand())
                {
                    comToonGemPrijs.CommandType=CommandType.StoredProcedure;
                    comToonGemPrijs.CommandText = "GemPrijsSoort";
                    var parGemPrijs = comToonGemPrijs.CreateParameter();
                    parGemPrijs.ParameterName = "@Soort";
                    parGemPrijs.Value = soort;
                    comToonGemPrijs.Parameters.Add(parGemPrijs);
                    conTuin.Open();
                    var resultaat = comToonGemPrijs.ExecuteScalar();
                    if (resultaat == null)
                    {
                        throw new Exception("Geen geldige soort ingevoerd");

                    }
                    else
                    {
                        return (Decimal) resultaat;
                    }

                }
            }
        }
    }
}
