using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                using (var comAutoNumber = conTuin.CreateCommand())
                {
                    comAutoNumber.CommandType=CommandType.StoredProcedure;
                    comAutoNumber.CommandText = "GeefAutonumber";
                    eenLeverancier.LevNr = Convert.ToInt32(comAutoNumber.ExecuteScalar());
                    
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

        public PlantEigenschappen PlantEigenschappenRaadplegen(Decimal plantNr)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comEigenschappen = conTuin.CreateCommand())
                {
                    comEigenschappen.CommandType=CommandType.StoredProcedure;
                    comEigenschappen.CommandText = "PlantenInfoRaadplegen";

                    var parPLantNr = comEigenschappen.CreateParameter();
                    parPLantNr.ParameterName = "@Plantennr";
                    parPLantNr.Value = plantNr;
                    parPLantNr.DbType=DbType.Decimal;
                    comEigenschappen.Parameters.Add(parPLantNr);

                    var parNaam = comEigenschappen.CreateParameter();
                    parNaam.ParameterName = "@PlantNaam";
                    parNaam.DbType=DbType.String;
                    parNaam.Size = 50;
                    parNaam.Direction=ParameterDirection.Output;
                    comEigenschappen.Parameters.Add(parNaam);

                    var parSoort = comEigenschappen.CreateParameter();
                    parSoort.ParameterName = "@PlantSoort";
                    parSoort.DbType = DbType.String;
                    parSoort.Size = 50;
                    parSoort.Direction = ParameterDirection.Output;
                    comEigenschappen.Parameters.Add(parSoort);

                    var parLevNaam = comEigenschappen.CreateParameter();
                    parLevNaam.ParameterName = "@LeverancierNaam";
                    parLevNaam.DbType=DbType.String;
                    parLevNaam.Size = 50;
                    parLevNaam.Direction=ParameterDirection.Output;
                    comEigenschappen.Parameters.Add(parLevNaam);

                    var parKleur = comEigenschappen.CreateParameter();
                    parKleur.ParameterName = "PlantKleur";
                    parKleur.DbType=DbType.String;
                    parKleur.Size = 50;
                    parKleur.Direction=ParameterDirection.Output;
                    comEigenschappen.Parameters.Add(parKleur);

                    var parKostPrijs = comEigenschappen.CreateParameter();
                    parKostPrijs.ParameterName = "@PlantPrijs";
                    parKostPrijs.DbType=DbType.Currency;
                    parKostPrijs.Direction=ParameterDirection.Output;
                    comEigenschappen.Parameters.Add(parKostPrijs);

                    conTuin.Open();
                    comEigenschappen.ExecuteNonQuery();
                    if (parKostPrijs.Value == DBNull.Value)
                    {
                        throw new Exception("plant bestaat niet");
                    }
                    else
                    {
                        return new PlantEigenschappen((String)parNaam.Value,(String)parSoort.Value
                                                       ,(String)parLevNaam.Value,(String)parKleur.Value
                                                       ,(Decimal)parKostPrijs.Value);
                    }
                }
            }
        }

        public List<Soort> GetSoorten()
        {
            var soorten = new List<Soort>();
            var manager= new TuincentrumDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var comSoorten = conTuin.CreateCommand())
                {
                    comSoorten.CommandType= CommandType.Text;
                    comSoorten.CommandText = "Select SoortNr, Soort from Soorten Order by Soort";
                    conTuin.Open();
                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        var soortPos = rdrSoorten.GetOrdinal("soort");
                        var soortNrPos = rdrSoorten.GetOrdinal("SoortNr");
                        while (rdrSoorten.Read())
                        {
                            soorten.Add(new Soort(rdrSoorten.GetString(soortPos),rdrSoorten.GetInt32(soortNrPos)));
                        }
                    }
                   
                }
            }
            return soorten;
        }
        
        //opgave 9 aanpassingen  



        public List<Plant> getPlanten(int soortnr)    //veranderd van List<String> naar List<Plant>
        {
            List<Plant> planten = new List<Plant>(); //var planten = new List<String>();
            var manager = new TuincentrumDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var comPlanten = conTuin.CreateCommand())
                {
                    comPlanten.CommandType= CommandType.Text;
                    comPlanten.CommandText = "Select * from planten where soortnr=@soortnr order by naam";
                    var parSoortNr = comPlanten.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    parSoortNr.Value = soortnr;
                    comPlanten.Parameters.Add(parSoortNr);
                    
                    conTuin.Open();
                    using (var rdrPLanten = comPlanten.ExecuteReader())
                    
                    {
                        Int32 plantNrPos = rdrPLanten.GetOrdinal("PlantNr");
                        Int32 plantNaamPos = rdrPLanten.GetOrdinal("Naam");
                        Int32 levNrPos = rdrPLanten.GetOrdinal("Levnr");
                        Int32 kleurPos = rdrPLanten.GetOrdinal("Kleur");
                        Int32 prijsPos = rdrPLanten.GetOrdinal("VerkoopPrijs");
                        while (rdrPLanten.Read())
                        {
                            planten.Add(new Plant(rdrPLanten.GetString(plantNaamPos),rdrPLanten.GetInt32(plantNrPos),
                                rdrPLanten.GetInt32(levNrPos),rdrPLanten.GetString(kleurPos),rdrPLanten.GetDecimal(prijsPos)));

                        }
                        
                    }
                }
            }
            return planten;
        }

        public void GewijzigdePlantenOpslaan(List<Plant> gewijzigdePlanten)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comUpdate = conTuincentrum.CreateCommand())
                {
                    comUpdate.CommandType=CommandType.Text;
                    comUpdate.CommandText ="Update planten set Kleur=@kleur, VerkoopPrijs=@prijs where PlantNr=@plantnr ";
                    
                    var parKleur = comUpdate.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    comUpdate.Parameters.Add(parKleur);

                    var parPrijs = comUpdate.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    comUpdate.Parameters.Add(parPrijs);

                    var parPlantNr = comUpdate.CreateParameter();
                    parPlantNr.ParameterName = "@plantnr";
                    comUpdate.Parameters.Add(parPlantNr);
                    conTuincentrum.Open();

                    foreach (Plant eenPlant in gewijzigdePlanten)
                    {
                       
                        parPlantNr.Value = eenPlant.PlantNr;
                        parKleur.Value = eenPlant.Kleur;
                        parPrijs.Value = eenPlant.VerkoopPrijs;
                        if(comUpdate.ExecuteNonQuery()==0)
                          throw new Exception(eenPlant.PlantNaam+" opslaan mislukt");
                    }
                }
            }
        }

        public ObservableCollection<Leverancier> GetLeverancier()
        {
            ObservableCollection<Leverancier> leveranciers = new ObservableCollection<Leverancier>();
            TuincentrumDbManager manager = new TuincentrumDbManager();
            using (var conLeveranciers = manager.GetConnection())
            {
                using (var comLeveranciers = conLeveranciers.CreateCommand())
                {
                    comLeveranciers.CommandType = CommandType.Text;
                    comLeveranciers.CommandText = "select * from Leveranciers";
                    conLeveranciers.Open();

                    using (var rdrLeveranciers = comLeveranciers.ExecuteReader())
                    {
                        Int32 levNrPos = rdrLeveranciers.GetOrdinal("LevNr");
                        Int32 naamPos = rdrLeveranciers.GetOrdinal("Naam");
                        Int32 adresPos = rdrLeveranciers.GetOrdinal("Adres");
                        Int32 postNrPos = rdrLeveranciers.GetOrdinal("PostNr");
                        Int32 woonplPos = rdrLeveranciers.GetOrdinal("Woonplaats");
                        Int32 versiePos = rdrLeveranciers.GetOrdinal("Versie");

                        while (rdrLeveranciers.Read())
                        {
                            leveranciers.Add(new Leverancier(rdrLeveranciers.GetInt32(levNrPos),
                                            rdrLeveranciers.GetString(naamPos),rdrLeveranciers.GetString(adresPos),
                                            rdrLeveranciers.GetString(postNrPos),rdrLeveranciers.GetString(woonplPos),
                                            rdrLeveranciers.GetValue(versiePos)));
                        }
                        
                    }
                }
            }
            return leveranciers;
        }

        public List<String> GetPostCodes()
        {
           List<string> postcodes = new List<string>();
           var manager = new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comPostCodes = conTuincentrum.CreateCommand())
                {
                    comPostCodes.CommandType= CommandType.StoredProcedure;
                    comPostCodes.CommandText = "PostNummers";
                    conTuincentrum.Open();

                    using (var rdrPostCodes = comPostCodes.ExecuteReader())
                    {
                        Int32 postNrPos = rdrPostCodes.GetOrdinal("PostNr");
                        while (rdrPostCodes.Read())
                        {
                            postcodes.Add(rdrPostCodes.GetString(postNrPos));
                        }
                    }
                }
            }
            return postcodes;
        }

        //functie voor het wegschrijven van de verwijderde leveranciersrecords naar de database
        public void SchrijfVerwijderingen(List<Leverancier> leveranciers)
        {
            var manager = new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comDelete = conTuincentrum.CreateCommand())
                {
                    comDelete.CommandType = CommandType.Text;
                    comDelete.CommandText = "Delete From Leveranciers Where Levnr=@levnr";
                    var parLevNr = comDelete.CreateParameter();
                    parLevNr.ParameterName = "@levnr";
                    comDelete.Parameters.Add(parLevNr);
                    conTuincentrum.Open();
                    

                    foreach (Leverancier eenLeverancier in leveranciers)
                    {
                        parLevNr.Value = eenLeverancier.LevNr;
                        if (comDelete.ExecuteNonQuery() == 0)
                        {
                         throw new Exception("Iemand was je voor");   
                        }
                    }

                }
            }
        }

        //functie voor het wegschrijven van de toegevoegde leveranciersrecords naar de database
        public void SchrijfToevoegingen(List<Leverancier> leveranciers)
        {
            var manager=new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comInsert = conTuincentrum.CreateCommand())
                {
                    comInsert.CommandType=CommandType.Text;
                    comInsert.CommandText =
                        "Insert into Leveranciers(Naam, Adres,PostNr,Woonplaats)  values (@naam,@adres,@postnr,@woonplaats)";

                    var parNaam = comInsert.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comInsert.Parameters.Add(parNaam);

                    var parAdres = comInsert.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    comInsert.Parameters.Add(parAdres);

                    var parPostnr = comInsert.CreateParameter();
                    parPostnr.ParameterName = "@postnr";
                    comInsert.Parameters.Add(parPostnr);

                    var parWoonPl = comInsert.CreateParameter();
                    parWoonPl.ParameterName = "@woonplaats";
                    comInsert.Parameters.Add(parWoonPl);

                    conTuincentrum.Open();

                    foreach (var eenleverancier in leveranciers)
                    {
                        parNaam.Value = eenleverancier.Naam;
                        parAdres.Value = eenleverancier.Adres;
                        parPostnr.Value = eenleverancier.Postcode;
                        parWoonPl.Value = eenleverancier.Woonplaats;
                        comInsert.ExecuteNonQuery();
                        

                    }
                }
            }
        }

        public void SchrijfWijzigingen(List<Leverancier> leveranciers)
        {
            var manager=new TuincentrumDbManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comUpdate = conTuincentrum.CreateCommand())
                {
                    comUpdate.CommandType=CommandType.Text;
                    comUpdate.CommandText =
                        "Update Leveranciers set Naam=@naam, Adres=@adres, PostNr=@postnr, Woonplaats=@woonplaats where LevNr=@levnr and Versie=@versie";

                    var parLevnr = comUpdate.CreateParameter();
                    parLevnr.ParameterName = "@levnr";
                    comUpdate.Parameters.Add(parLevnr);
                    
                    var parNaam = comUpdate.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comUpdate.Parameters.Add(parNaam);

                    var parAdres = comUpdate.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    comUpdate.Parameters.Add(parAdres);

                    var parPostnr = comUpdate.CreateParameter();
                    parPostnr.ParameterName = "@postnr";
                    comUpdate.Parameters.Add(parPostnr);

                    var parWoonPl = comUpdate.CreateParameter();
                    parWoonPl.ParameterName = "@woonplaats";
                    comUpdate.Parameters.Add(parWoonPl);

                    var parVersie = comUpdate.CreateParameter();
                    parVersie.ParameterName = "@versie";
                    comUpdate.Parameters.Add(parVersie);

                    conTuincentrum.Open();

                    foreach (var eenLeverancier in leveranciers)
                    {
                        parLevnr.Value = eenLeverancier.LevNr;
                        parNaam.Value = eenLeverancier.Naam;
                        parAdres.Value = eenLeverancier.Adres;
                        parPostnr.Value = eenLeverancier.Postcode;
                        parWoonPl.Value = eenLeverancier.Woonplaats;
                        parVersie.Value = eenLeverancier.Versie;

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
