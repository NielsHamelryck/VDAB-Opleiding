using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class TuincentrumManager
    {
        public List<Soort> GetSoorten()
        {
            List<Soort> soorten = new List<Soort>();
            var manager = new TuincentrumDBManager();

            using(var conTuincentrum = manager.GetConnection())
            {
                using (var comSoorten = conTuincentrum.CreateCommand())
                {
                    comSoorten.CommandType=CommandType.Text;
                    comSoorten.CommandText = "select Soort ,Soortnr from Soorten order by Soort";

                    conTuincentrum.Open();

                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        Int32 soortnrPos = rdrSoorten.GetOrdinal("SoortNr");
                        Int32 soortPos = rdrSoorten.GetOrdinal("Soort");

                        while (rdrSoorten.Read())
                        {
                            soorten.Add(new Soort(rdrSoorten.GetInt32(soortnrPos),
                                rdrSoorten.GetString(soortPos)));
                        }
                    }
                }
            }
            
            return soorten;
        }

        public ObservableCollection<Plant> GetPlanten(int soortnr)
        {
            ObservableCollection<Plant> planten = new ObservableCollection<Plant>();
            var manager = new TuincentrumDBManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comPlanten = conTuincentrum.CreateCommand())
                {
                    comPlanten.CommandType = CommandType.Text;
                    comPlanten.CommandText = "select * from planten where SoortNr=@soortnr";

                    var parSoortnr = comPlanten.CreateParameter();
                    parSoortnr.ParameterName = "@soortnr";
                    parSoortnr.Value = soortnr;
                    comPlanten.Parameters.Add(parSoortnr);

                    conTuincentrum.Open();

                    using (var rdrPlanten = comPlanten.ExecuteReader())
                    {
                        Int32 PlantNrPos = rdrPlanten.GetOrdinal("PlantNr");
                        Int32 NaamPos = rdrPlanten.GetOrdinal("Naam");
                        Int32 SoortNrPos = rdrPlanten.GetOrdinal("SoortNr");
                        Int32 LevnrPos = rdrPlanten.GetOrdinal("Levnr");
                        Int32 KleurPos = rdrPlanten.GetOrdinal("Kleur");
                        Int32 prijsPos = rdrPlanten.GetOrdinal("VerkoopPrijs");

                        while (rdrPlanten.Read())
                        {
                            planten.Add(new Plant(rdrPlanten.GetInt32(PlantNrPos),
                                rdrPlanten.GetString(NaamPos),
                                rdrPlanten.GetInt32(SoortNrPos),
                                rdrPlanten.GetInt32(LevnrPos),
                                rdrPlanten.GetString(KleurPos),
                                rdrPlanten.GetDecimal(prijsPos)));
                        }
                    }
                }
            }
            
            return planten;
        }
    }
}
