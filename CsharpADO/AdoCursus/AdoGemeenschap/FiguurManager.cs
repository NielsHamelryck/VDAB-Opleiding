using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class FiguurManager
    {
        public List<Figuur> getFiguren()
        {
            List<Figuur> figuren = new List<Figuur>();
            var manager = new StripDBManager();
            using (var conStrips = manager.GetConnection())
            {
                using (var comFiguren = conStrips.CreateCommand())
                {
                    comFiguren.CommandType=CommandType.Text;
                    comFiguren.CommandText = "select * from Figuren";
                    conStrips.Open();

                    using (var rdrFiguren = comFiguren.ExecuteReader())
                    {
                        Int32 idPos = rdrFiguren.GetOrdinal("ID");
                        Int32 naamPos = rdrFiguren.GetOrdinal("Naam");
                        Int32 versiePos = rdrFiguren.GetOrdinal("Versie");

                        while (rdrFiguren.Read())
                        {
                            figuren.Add(new Figuur(rdrFiguren.GetInt32(idPos),
                                rdrFiguren.GetString(naamPos),
                                rdrFiguren.GetValue(versiePos)));
                        }
                    }
                }
            }


            return figuren;
        }

        public void SchrijfWijzigingen(List<Figuur> gewijzigdeFiguren)
        {
            var manager = new StripDBManager();
            using (var conStrips = manager.GetConnection())
            {
                using (var comUpdate = conStrips.CreateCommand())
                {
                    comUpdate.CommandType = CommandType.Text;
                    comUpdate.CommandText = "Update Figuren set Naam=@naam where ID=@id and Versie=@versie";

                    var parNaam = comUpdate.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comUpdate.Parameters.Add(parNaam);

                    var parId = comUpdate.CreateParameter();
                    parId.ParameterName = "@id";
                    comUpdate.Parameters.Add(parId);

                    var parVersie = comUpdate.CreateParameter();
                    parVersie.ParameterName = "@versie";
                    comUpdate.Parameters.Add(parVersie);

                    conStrips.Open();

                    foreach (var eenFiguur in gewijzigdeFiguren)
                    {
                        parNaam.Value = eenFiguur.Naam;
                        parId.Value = eenFiguur.ID;
                        parVersie.Value = eenFiguur.Versie;
                        if (comUpdate.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("Iemand was je voor");
                        }

                        
                    }
                }
            }
        }
    }
}
