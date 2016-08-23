using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class BierManager
    {
        public static Dictionary<int, string> dictSoorten ;
        public static Dictionary<int, string> dictBrouwer ;
        public List<Soort> GetSoorten()
        {
            List<Soort> soorten = new List<Soort>();
            var manager = new BierenDbManager();
            dictSoorten = GetDictionarySoorten();
            dictBrouwer = GetDictionaryBrouwers();
            using (var conBieren = manager.GetConnection())
            {
                using (var comSoorten = conBieren.CreateCommand())
                {
                    comSoorten.CommandType=CommandType.Text;
                    comSoorten.CommandText = "select * from Soorten order by soort";
                    conBieren.Open();

                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        Int32 soortNrPos = rdrSoorten.GetOrdinal("SoortNr");
                        Int32 naamPos = rdrSoorten.GetOrdinal("Soort");

                        while (rdrSoorten.Read())
                        {
                           soorten.Add(new Soort(rdrSoorten.GetInt32(soortNrPos),
                                                rdrSoorten.GetString(naamPos)));
                        }
                    }
                }
            }
            
            return soorten;
        }

        public List<Bier> GetBieren(int soortNr)
        {
            var manager = new BierenDbManager();
            
            List<Bier> bieren = new List<Bier>();

            using (var conBier = manager.GetConnection())
            {
                using (var comBieren = conBier.CreateCommand())
                {
                    comBieren.CommandType=CommandType.Text;
                    comBieren.CommandText = "Select * from bieren where SoortNr=@soortnr order by Naam";

                    var parSoortnr = comBieren.CreateParameter();
                    parSoortnr.ParameterName = "@soortnr";
                    parSoortnr.Value = soortNr;
                    comBieren.Parameters.Add(parSoortnr);

                    conBier.Open();

                    using (var rdrBieren = comBieren.ExecuteReader())
                    {
                        Int32 bierNrpos = rdrBieren.GetOrdinal("BierNr");
                        Int32 naamPos = rdrBieren.GetOrdinal("Naam");
                        Int32 brouwerNrPos = rdrBieren.GetOrdinal("BrouwerNr");
                        Int32 soortNrPos = rdrBieren.GetOrdinal("SoortNr");
                        Int32 alcoholPos = rdrBieren.GetOrdinal("Alcohol");
                        Single? alcohol;
                        while (rdrBieren.Read())
                        {
                            if (rdrBieren.IsDBNull(alcoholPos))
                            {
                                alcohol = null;
                            }
                            else alcohol = rdrBieren.GetFloat(alcoholPos);
                            bieren.Add(new Bier(rdrBieren.GetInt32(bierNrpos),
                                rdrBieren.GetString(naamPos),
                                rdrBieren.GetInt32(brouwerNrPos),
                                rdrBieren.GetInt32(soortNrPos),
                                alcohol));
                        }

                    }


                }
            }


            return bieren;

        }

        public ObservableCollection<BierEigenschappen> GetBierEigenschappen(int soortnr)
        {
            ObservableCollection<BierEigenschappen> bierEigenschappen= new ObservableCollection<BierEigenschappen>();
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comBieren = conBieren.CreateCommand())
                {
                    comBieren.CommandType = CommandType.Text;
                    comBieren.CommandText =
                        "select Bieren.Naam, Soorten.Soort, Brouwers.BrNaam , Bieren.Alcohol , Bieren.SSMA_TimeStamp, Bieren.BierNr from Brouwers inner join Bieren on Brouwers.BrouwerNr=Bieren.BrouwerNr inner join Soorten on Bieren.SoortNr = Soorten.Soortnr where Bieren.Soortnr=@soortnr";
                    var parSoortNr = comBieren.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    parSoortNr.Value = soortnr;
                    comBieren.Parameters.Add(parSoortNr);
                    conBieren.Open();

                    using (var rdrBierEigenschappen = comBieren.ExecuteReader())
                    {
                        Int32 BierNaamPos = rdrBierEigenschappen.GetOrdinal("Naam");
                        Int32 SoortNaamPos = rdrBierEigenschappen.GetOrdinal("Soort");
                        Int32 BrNaamPos = rdrBierEigenschappen.GetOrdinal("BrNaam");
                        Int32 AlcoholPos = rdrBierEigenschappen.GetOrdinal("Alcohol");
                        Int32 versiePos = rdrBierEigenschappen.GetOrdinal("SSMA_TimeStamp");
                        Int32 BierNrPos = rdrBierEigenschappen.GetOrdinal("BierNr");
                        Single? alcohol;
                        while (rdrBierEigenschappen.Read())
                        {
                            if (rdrBierEigenschappen.IsDBNull(AlcoholPos))
                            {
                                alcohol = null;
                            }
                            else
                            {
                                alcohol = rdrBierEigenschappen.GetFloat(AlcoholPos);
                            }
                            bierEigenschappen.Add(new BierEigenschappen(rdrBierEigenschappen.GetString(BierNaamPos),
                                rdrBierEigenschappen.GetString(BrNaamPos),rdrBierEigenschappen.GetString(SoortNaamPos),
                                alcohol,rdrBierEigenschappen.GetValue(versiePos),rdrBierEigenschappen.GetInt32(BierNrPos))); 
                        }
                    }
                }

            }



            return bierEigenschappen;
        }

        public Dictionary<int, string> GetDictionarySoorten()
        {
            Dictionary<int,string> dictionary = new Dictionary<int, string>();
            
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comSoorten = conBieren.CreateCommand())
                {
                    comSoorten.CommandType=CommandType.Text;
                    comSoorten.CommandText = "select SoortNr,Soort from Soorten";
                    conBieren.Open();
                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        Int32 soortNrPos = rdrSoorten.GetOrdinal("SoortNr");
                        Int32 soortNaamPos = rdrSoorten.GetOrdinal("Soort");

                        while (rdrSoorten.Read())
                        {
                            dictionary.Add(rdrSoorten.GetInt32(soortNrPos),rdrSoorten.GetString(soortNaamPos));
                        }
                    }
                    
                }
            }

            
            return dictionary;
            
        }

        public Dictionary<int, string> GetDictionaryBrouwers()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            var manager = new BierenDbManager();
            {
                using (var conBieren = manager.GetConnection())
                {
                    using (var comBrouwers = conBieren.CreateCommand())
                    {
                        comBrouwers.CommandType=CommandType.Text;
                        comBrouwers.CommandText = "select BrouwerNr, BrNaam from brouwers";
                        conBieren.Open();

                        using (var rdrBrouwers = comBrouwers.ExecuteReader())
                        {
                            Int32 BrouwerNrPos = rdrBrouwers.GetOrdinal("BrouwerNr");
                            Int32 BrNaamPos = rdrBrouwers.GetOrdinal("BrNaam");


                            while (rdrBrouwers.Read())
                            {
                                dictionary.Add(rdrBrouwers.GetInt32(BrouwerNrPos),rdrBrouwers.GetString(BrNaamPos));
                            }
                        }
                    }
                }
            }
            return dictionary;
        }

        
        

        public void Toevoegingen(List<BierEigenschappen> bieren)
        {

            var manager= new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comToevoegen = conBieren.CreateCommand())
                {
                    comToevoegen.CommandType= CommandType.Text;
                    comToevoegen.CommandText =
                        "Insert into Bieren (Naam,BrouwerNr,SoortNr,Alcohol) values (@naam,@brouwernr,@soortnr,@alcohol)";

                    var parNaam = comToevoegen.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comToevoegen.Parameters.Add(parNaam);

                    var parBrouwerNr = comToevoegen.CreateParameter();
                    parBrouwerNr.ParameterName = "@brouwernr";
                    comToevoegen.Parameters.Add(parBrouwerNr);

                    var parSoortNr = comToevoegen.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    comToevoegen.Parameters.Add(parSoortNr);

                    var parAlcohol = comToevoegen.CreateParameter();
                    parAlcohol.ParameterName = "@alcohol";
                    comToevoegen.Parameters.Add(parAlcohol);

                   
                   

                    conBieren.Open();

                    foreach (var bier in bieren)
                    {
                        parNaam.Value = bier.Naam;
                        foreach (var brouwer in dictBrouwer)
                        {
                            if (brouwer.Value == bier.Brouwer)
                            {
                                parBrouwerNr.Value = Convert.ToInt32(brouwer.Key.ToString());
                            }
                        }
                        foreach (var soort in dictSoorten)
                        {
                            if (soort.Value == bier.Soort)
                            {
                                parSoortNr.Value = Convert.ToInt32(soort.Key.ToString());
                            }
                        }
                        if (bier.Alcohol == null)
                        {
                            parAlcohol.Value = DBNull.Value;
                        }
                        else
                        {
                            parAlcohol.Value = bier.Alcohol;
                        }
                        //parVersie.Value = bier.Versie;
                        comToevoegen.ExecuteNonQuery();
                    }




                }
            }

        }

        public void Verwijderingen(List<BierEigenschappen> oudebieren)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comDelete = conBieren.CreateCommand())
                {
                    comDelete.CommandType=CommandType.Text;
                    comDelete.CommandText = "Delete From Bieren where BierNr=@biernr";

                    var parBierNr = comDelete.CreateParameter();
                    parBierNr.ParameterName = "@biernr";
                    comDelete.Parameters.Add(parBierNr);

                    conBieren.Open();
                    foreach (var eenOudBier in oudebieren)
                    {
                        parBierNr.Value = eenOudBier.BierNr;
                        comDelete.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Wijzigingen(List<BierEigenschappen> gewijzigdeBieren)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comUpdate = conBieren.CreateCommand())
                {
                    comUpdate.CommandType=CommandType.Text;
                    comUpdate.CommandText = "Update Bieren set Naam=@naam, BrouwerNr=@brouwernr, SoortNr=@soortnr,Alcohol=@alcohol where BierNr=@biernr";

                    var parBierNr = comUpdate.CreateParameter();
                    parBierNr.ParameterName = "@biernr";
                    comUpdate.Parameters.Add(parBierNr);

                    var parNaam = comUpdate.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comUpdate.Parameters.Add(parNaam);

                    var parBrouwerNr = comUpdate.CreateParameter();
                    parBrouwerNr.ParameterName = "@brouwernr";
                    comUpdate.Parameters.Add(parBrouwerNr);

                    var parSoortNr = comUpdate.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    comUpdate.Parameters.Add(parSoortNr);

                    var parAlcohol = comUpdate.CreateParameter();
                    parAlcohol.ParameterName = "@alcohol";
                    comUpdate.Parameters.Add(parAlcohol);

                   
                    conBieren.Open();
                    foreach (var eenGewijzigdBier in gewijzigdeBieren)
                    {
                        parBierNr.Value = eenGewijzigdBier.BierNr;
                        parNaam.Value = eenGewijzigdBier.Naam;

                        foreach (var brouwer in dictBrouwer)
                        {
                            if (eenGewijzigdBier.Brouwer == brouwer.Value)
                            {
                                parBrouwerNr.Value = brouwer.Key;
                            }
                        }
                        foreach (var soort in dictSoorten)
                        {
                            if (eenGewijzigdBier.Soort == soort.Value)
                            {
                                parSoortNr.Value = soort.Key;
                            }
                        }

                        if (eenGewijzigdBier.Alcohol == null)
                        {
                            parAlcohol.Value = DBNull.Value;
                        }
                        else parAlcohol.Value = eenGewijzigdBier.Alcohol;

                       
                        comUpdate.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
