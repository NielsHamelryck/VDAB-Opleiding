using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace AdoGemeenschap
{
    public class TuincentrumManager
    {

        public Int64 LeverancierToevoegen(Leverancier leverancier)
        {
            try
            {
                var manager = new TuincentrumDBManager();
                using (var conTuincentrum = manager.GetConnection())
                {
                    using (var comToevoegen = conTuincentrum.CreateCommand())
                    {
                        comToevoegen.CommandType = CommandType.StoredProcedure;
                        comToevoegen.CommandText = "autonummer";

                        var parNaam = comToevoegen.CreateParameter();
                        parNaam.ParameterName = "@naam";
                        parNaam.Value = leverancier.Naam;
                        comToevoegen.Parameters.Add(parNaam);

                        var parAdres = comToevoegen.CreateParameter();
                        parAdres.ParameterName = "@adres";
                        parAdres.Value = leverancier.Adres;
                        comToevoegen.Parameters.Add(parAdres);

                        var parPostNr = comToevoegen.CreateParameter();
                        parPostNr.ParameterName = "@postnr";
                        parPostNr.Value = leverancier.PostNr;
                        comToevoegen.Parameters.Add(parPostNr);

                        var parPlaats = comToevoegen.CreateParameter();
                        parPlaats.ParameterName = "@woonplaats";
                        parPlaats.Value = leverancier.Woonplaats;
                        comToevoegen.Parameters.Add(parPlaats);
                        conTuincentrum.Open();
                        Int64 LevNr = Convert.ToInt64(comToevoegen.ExecuteScalar());

                        return LevNr;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problemen bij het toevoegen van een leverancier : " + ex.Message);
            }
        }

        public void VervangLeverancier(int lev1 , int lev2)
        {
            var manager= new TuincentrumDBManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                conTuincentrum.Open();
                using (var traVervangen = conTuincentrum.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var comWijzigen = conTuincentrum.CreateCommand())
                    {
                        comWijzigen.Transaction = traVervangen;
                        comWijzigen.CommandType=CommandType.Text;
                        comWijzigen.CommandText = "Update planten set Levnr=@lev2 where Levnr=@lev1";

                        var parLev1 = comWijzigen.CreateParameter();
                        parLev1.ParameterName = "@lev1";
                        parLev1.Value = lev1;
                        comWijzigen.Parameters.Add(parLev1);

                        var parLev2 = comWijzigen.CreateParameter();
                        parLev2.ParameterName = "@lev2";
                        parLev2.Value = lev2;
                        comWijzigen.Parameters.Add(parLev2);

                        if (comWijzigen.ExecuteNonQuery() == 0)
                        {
                            traVervangen.Rollback();
                            throw new Exception("Leverancier nrs bestaan niet");
                        }
                        
                    }
                    using (var comVerwijderen = conTuincentrum.CreateCommand())
                    {
                        comVerwijderen.Transaction = traVervangen;
                        comVerwijderen.CommandType=CommandType.Text;
                        comVerwijderen.CommandText = "Delete From Leveranciers where LevNr=@levnr";

                        var parLev1 = comVerwijderen.CreateParameter();
                        parLev1.ParameterName = "@levnr";
                        parLev1.Value = lev1;
                        comVerwijderen.Parameters.Add(parLev1);

                        if (comVerwijderen.ExecuteNonQuery() == 0)
                        {
                            traVervangen.Rollback();
                            throw new Exception("leverancier bestaat niet");
                        }

                    }
                    traVervangen.Commit();
                }
            }
        }

        public decimal BerekenGemKostprijsSoort(string soort)
        {
            var manager = new TuincentrumDBManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                conTuincentrum.Open();
                using (var traGemKostprijsBerekenen = conTuincentrum.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    using (var comGemKostprijs = conTuincentrum.CreateCommand())
                    {
                        comGemKostprijs.Transaction = traGemKostprijsBerekenen;
                        comGemKostprijs.CommandType=CommandType.Text;
                        comGemKostprijs.CommandText =
                            "select avg(verkoopprijs) as gemiddeldekostprijs from planten inner join soorten on planten.SoortNr=soorten.SoortNr where Soorten.Soort=@soort";

                        var parSoort = comGemKostprijs.CreateParameter();
                        parSoort.ParameterName = "@soort";
                        parSoort.Value = soort;
                        comGemKostprijs.Parameters.Add(parSoort);
                        

                        Object kostprijs = comGemKostprijs.ExecuteScalar();

                        if (kostprijs == null)
                        {
                            traGemKostprijsBerekenen.Rollback();
                            throw new Exception("Deze soort bestaat niet");
                            
                        }
                        traGemKostprijsBerekenen.Commit();
                        return (Decimal)kostprijs;

                    }
                    
                }
            }
        }

        public Plantgegevens GetPlantGegevens(int plantnr)
        {
            var gegevens = new Plantgegevens();
            var manager= new TuincentrumDBManager();

            var opties = new TransactionOptions();
            opties.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
           
                using (var traGetGegevens = new TransactionScope(TransactionScopeOption.Required, opties))
                {
                    using (var conTuincentrum = manager.GetConnection())
                    {
                        using (var comPLantGegevens = conTuincentrum.CreateCommand())
                        {
                            comPLantGegevens.CommandType=CommandType.Text;
                            comPLantGegevens.CommandText =
                                "Select Planten.Naam , Soorten.Soort, Leveranciers.Naam as leverancier , Planten.Kleur, Planten.VerkoopPrijs from Leveranciers inner join planten on Leveranciers.Levnr = planten.Levnr inner join Soorten on planten.SoortNr=Soorten.SoortNr where planten.Plantnr=@plantnr";

                            var parPlantnr = comPLantGegevens.CreateParameter();
                            parPlantnr.ParameterName = "@plantnr";
                            parPlantnr.Value = plantnr;
                            comPLantGegevens.Parameters.Add(parPlantnr);
                            conTuincentrum.Open();

                            using (var rdrGegevens = comPLantGegevens.ExecuteReader())
                            {
                                Int32 NaamPos = rdrGegevens.GetOrdinal("Naam");
                                Int32 SoortPos = rdrGegevens.GetOrdinal("Soort");
                                Int32 LeverancierPos = rdrGegevens.GetOrdinal("leverancier");
                                Int32 KleurPos = rdrGegevens.GetOrdinal("Kleur");
                                Int32 VerkoopPrijsPos = rdrGegevens.GetOrdinal("VerkoopPrijs");

                                while (rdrGegevens.Read())
                                {
                                    gegevens.Naam = rdrGegevens.GetString(NaamPos);
                                    gegevens.Soort = rdrGegevens.GetString(SoortPos);
                                    gegevens.Leverancier = rdrGegevens.GetString(LeverancierPos);
                                    gegevens.Kleur = rdrGegevens.GetString(KleurPos);
                                    gegevens.Kostprijs =   Math.Round(rdrGegevens.GetDecimal(VerkoopPrijsPos),2);
                                }
                            }
                            
                        }

                    }
                traGetGegevens.Complete();
                }
                
            
            return gegevens;
        }

        public List<Soort> GetSoorten()
        {
            List<Soort> soorten = new List<Soort>();
            var manager = new TuincentrumDBManager();
            try
            {
                using (var conTuincentrum = manager.GetConnection())
                {
                    using (var comSoorten = conTuincentrum.CreateCommand())
                    {
                        comSoorten.CommandType = CommandType.Text;
                        comSoorten.CommandText = "select SoortNr , Soort from Soorten order by soort";

                        conTuincentrum.Open();
                        using (var rdrSoorten = comSoorten.ExecuteReader())
                        {
                            Int32 SoortPos = rdrSoorten.GetOrdinal("Soort");
                            Int32 SoortNrPos = rdrSoorten.GetOrdinal("SoortNr");

                            while (rdrSoorten.Read())
                            {
                                soorten.Add(new Soort(rdrSoorten.GetInt32(SoortNrPos),
                                    rdrSoorten.GetString(SoortPos)));
                            }
                        }
                    }
                }


                return soorten;
            }
            catch (Exception ex)
            {  
                throw new Exception(ex.Message);
                
            }
        }

        public List<Plant> GetPlantgegevens(Int32 SoortNr)
        {
            List<Plant> planten = new List<Plant>();
            var manager = new TuincentrumDBManager();
            try
            {
                using (var conTuincentrum = manager.GetConnection())
                {
                    using (var comPlantGegevens = conTuincentrum.CreateCommand())
                    {
                        comPlantGegevens.CommandType=CommandType.Text;
                        comPlantGegevens.CommandText = "select * from planten where SoortNr=@soortnr order by Naam";

                        var parSoortnr = comPlantGegevens.CreateParameter();
                        parSoortnr.ParameterName = "@soortnr";
                        parSoortnr.Value = SoortNr;
                        comPlantGegevens.Parameters.Add(parSoortnr);

                        conTuincentrum.Open();

                        using (var rdrPlanten = comPlantGegevens.ExecuteReader())
                        {
                            Int32 PlantNrPos = rdrPlanten.GetOrdinal("PlantNr");
                            Int32 NaamPos = rdrPlanten.GetOrdinal("Naam");
                            Int32 SoortNrPos = rdrPlanten.GetOrdinal("SoortNr");
                            Int32 LevnrPos = rdrPlanten.GetOrdinal("Levnr");
                            Int32 KleurPos = rdrPlanten.GetOrdinal("Kleur");
                            Int32 VerkoopPrijs = rdrPlanten.GetOrdinal("VerkoopPrijs");

                            while (rdrPlanten.Read())
                            {
                                planten.Add(new Plant(rdrPlanten.GetInt32(PlantNrPos),
                                            rdrPlanten.GetString(NaamPos),
                                            rdrPlanten.GetInt32(SoortNrPos),
                                            rdrPlanten.GetInt32(LevnrPos),
                                            rdrPlanten.GetString(KleurPos),
                                            rdrPlanten.GetDecimal(VerkoopPrijs)));
                            }

                        }
                    }
                }
                return planten;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        
        public void SchrijfWijzigingen(List<Plant> planten  )
        {
           
            var manager = new TuincentrumDBManager();
            
                using (var conTuincentrum = manager.GetConnection())
                {
                    using (var comUpdate = conTuincentrum.CreateCommand())
                    {
                        comUpdate.CommandType = CommandType.Text;
                        comUpdate.CommandText =
                            "Update planten set  Kleur=@kleur , VerkoopPrijs=@verkoopprijs where PlantNr=@plantnr";



                        var parPlantNr = comUpdate.CreateParameter();
                        parPlantNr.ParameterName = "@plantnr";
                        comUpdate.Parameters.Add(parPlantNr);

                        var parKleur = comUpdate.CreateParameter();
                        parKleur.ParameterName = "@kleur";
                        comUpdate.Parameters.Add(parKleur);

                        var parPrijs = comUpdate.CreateParameter();
                        parPrijs.ParameterName = "@verkoopprijs";
                        comUpdate.Parameters.Add(parPrijs);

                        conTuincentrum.Open();

                        foreach (var plant in planten)
                        {
                            
                                parPlantNr.Value = plant.PlantNr;
                                parKleur.Value = plant.Kleur;
                                parPrijs.Value = plant.VerkoopPrijs;
                                if (comUpdate.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception(plant.Naam+" opslaan mislukt");
                                }
                          

                        }
                    }
                }
        }

        public ObservableCollection<Leverancier> GetLeveranciers()
        {
            ObservableCollection<Leverancier> leveranciers = new ObservableCollection<Leverancier>();
            var manager= new TuincentrumDBManager();
            using(var conTuincentrum = manager.GetConnection())
            {

                using (var comLeveranciers = conTuincentrum.CreateCommand())
                {
                    comLeveranciers.CommandType=CommandType.Text;
                    comLeveranciers.CommandText = "Select * from Leveranciers";

                    conTuincentrum.Open();
                    using (var rdrLeveranciers = comLeveranciers.ExecuteReader())
                    {
                        Int32 LevNrPos = rdrLeveranciers.GetOrdinal("LevNr");
                        Int32 NaamPos = rdrLeveranciers.GetOrdinal("Naam");
                        Int32 AdresPos = rdrLeveranciers.GetOrdinal("Adres");
                        Int32 PostNrPos = rdrLeveranciers.GetOrdinal("PostNr");
                        Int32 WoonPlaatsPos = rdrLeveranciers.GetOrdinal("Woonplaats");
                        Int32 VersiePos = rdrLeveranciers.GetOrdinal("Versie");

                        while (rdrLeveranciers.Read())
                        {
                            Leverancier leverancier = new Leverancier(
                                rdrLeveranciers.GetInt32(LevNrPos),
                                rdrLeveranciers.GetString(NaamPos),
                                rdrLeveranciers.GetString(AdresPos),
                                rdrLeveranciers.GetString(PostNrPos),
                                rdrLeveranciers.GetString(WoonPlaatsPos),
                                rdrLeveranciers.GetValue(VersiePos));
                            leveranciers.Add(leverancier);
                        }
                    }
                }
            }
            
            return leveranciers;
        }


        public List<Leverancier> SchrijfVerwijderingen(List<Leverancier> leveranciers)
        {
            List<Leverancier> nietVerwijderdeLeveranciers = new List<Leverancier>();
            var manager = new TuincentrumDBManager();
            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comDelete = conTuincentrum.CreateCommand())
                {
                    comDelete.CommandType = CommandType.Text;
                    comDelete.CommandText = "Delete from Leveranciers Where LevNr=@levnr and Versie=@versie";

                    var parLevnr = comDelete.CreateParameter();
                    parLevnr.ParameterName = "@levnr";
                    comDelete.Parameters.Add(parLevnr);
                    
                    var parVersie = comDelete.CreateParameter();
                    parVersie.ParameterName = "@versie";
                    comDelete.Parameters.Add(parVersie);

                    conTuincentrum.Open();
                    foreach (var leverancier in leveranciers)
                    {
                        try
                        {
                            parLevnr.Value = leverancier.LevNr;
                            parLevnr.Value = leverancier.Versie;
                            if(comDelete.ExecuteNonQuery()==0)
                                nietVerwijderdeLeveranciers.Add(leverancier);
                        }
                        catch (Exception)
                        {
                            nietVerwijderdeLeveranciers.Add(leverancier);
                        }
                    }

                }
            }
            return nietVerwijderdeLeveranciers;
        }

        public List<Leverancier> ToevoegenLeveranciers(List<Leverancier> leveranciers)
        {
            List<Leverancier> NietToegevoegdeLeveranciers = new List<Leverancier>();
            var manager = new TuincentrumDBManager();
            using (var conTuinCentrum = manager.GetConnection())
            {
                using (var comInsert = conTuinCentrum.CreateCommand())
                {
                    comInsert.CommandType=CommandType.Text;
                    comInsert.CommandText =
                        "Insert into Leveranciers (Naam,Adres,PostNr,Woonplaats) values (@naam,@adres,@postnr,@woonplaats)";

                    var parNaam = comInsert.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comInsert.Parameters.Add(parNaam);

                    var parAdres = comInsert.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    comInsert.Parameters.Add(parAdres);

                    var parPostNr = comInsert.CreateParameter();
                    parPostNr.ParameterName = "@postnr";
                    comInsert.Parameters.Add(parPostNr);

                    var parWoonplaats = comInsert.CreateParameter();
                    parWoonplaats.ParameterName = "@woonplaats";
                    comInsert.Parameters.Add(parWoonplaats);

                    conTuinCentrum.Open();

                    foreach (var eenLeverancier in leveranciers)
                    {
                        try
                        {
                            parNaam.Value = eenLeverancier.Naam;
                            parAdres.Value = eenLeverancier.Adres;
                            parPostNr.Value = eenLeverancier.PostNr;
                            parWoonplaats.Value = eenLeverancier.Woonplaats;
                            if (comInsert.ExecuteNonQuery() == 0)
                                NietToegevoegdeLeveranciers.Add(eenLeverancier);
                        }
                        catch (Exception)
                        {
                            NietToegevoegdeLeveranciers.Add(eenLeverancier);
                        }

                    }
                    

                }
            }


            return NietToegevoegdeLeveranciers;
        }

        public List<Leverancier> LeverancierWijzigen(List<Leverancier> gewijzigdeLeveranciers)
        {
            List<Leverancier> NietGewijzigdeLeveranciers = new List<Leverancier>();
            
            var manager = new TuincentrumDBManager();

            using (var conTuincentrum = manager.GetConnection())
            {
                using (var comUpdate = conTuincentrum.CreateCommand())
                {
                    comUpdate.CommandType= CommandType.Text;
                    comUpdate.CommandText =
                        "Update Leveranciers set Naam=@naam , Adres=@adres , PostNr=@postnr, Woonplaats=@woonplaats where LevNr=@levnr and Versie=@versie";

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

                    var parWoonplaats = comUpdate.CreateParameter();
                    parWoonplaats.ParameterName = "@woonplaats";
                    comUpdate.Parameters.Add(parWoonplaats);

                    var parVersie = comUpdate.CreateParameter();
                    parVersie.ParameterName = "@versie";
                    comUpdate.Parameters.Add(parVersie);
                    conTuincentrum.Open();
                    foreach (var eenrleverancier in gewijzigdeLeveranciers)
                    {
                        try
                        {
                            parLevnr.Value = eenrleverancier.LevNr;
                            parNaam.Value = eenrleverancier.Naam;
                            parAdres.Value = eenrleverancier.Adres;
                            parPostnr.Value = eenrleverancier.PostNr;
                            parWoonplaats.Value = eenrleverancier.Woonplaats;
                            parVersie.Value = eenrleverancier.Versie;
                            if (comUpdate.ExecuteNonQuery() == 0)
                            {
                                NietGewijzigdeLeveranciers.Add(eenrleverancier);
                            }
                        }
                        catch (Exception)
                        {
                            NietGewijzigdeLeveranciers.Add(eenrleverancier);
                        }
                    }

                }
            }
            return NietGewijzigdeLeveranciers;
        }
    }
    }

