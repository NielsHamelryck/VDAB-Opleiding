using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace AdoGemeenschap
{
    public class BrouwerManager
    {

        public ObservableCollection<Brouwer> GetBrouwersBeginNaam(String beginNaam)
        {
            
                ObservableCollection<Brouwer> brouwers = new ObservableCollection<Brouwer>();
                var manager = new BierenDbManager();
                using (var conBieren = manager.GetConnection())
                {
                    using (var comBrouwers = conBieren.CreateCommand())
                    {
                        comBrouwers.CommandType = CommandType.Text;
                        if (beginNaam != string.Empty)
                        {
                            comBrouwers.CommandText =
                                "select * from Brouwers where BrNaam like @zoals order by BrNaam";
                            var parZoals = comBrouwers.CreateParameter();
                            parZoals.ParameterName = "@zoals";
                            parZoals.Value = beginNaam + "%";
                            comBrouwers.Parameters.Add(parZoals);
                        }
                        else comBrouwers.CommandText = "select * from Brouwers";
                        conBieren.Open();
                        using (var rdrBrouwers = comBrouwers.ExecuteReader())
                        {
                            Int32 brouwerNrPos = rdrBrouwers.GetOrdinal("BrouwerNr");
                            Int32 brNaamPos = rdrBrouwers.GetOrdinal("BrNaam");
                            Int32 adresPos = rdrBrouwers.GetOrdinal("Adres");
                            Int32 postcodePos = rdrBrouwers.GetOrdinal("Postcode");
                            Int32 gemeentePos = rdrBrouwers.GetOrdinal("Gemeente");
                            Int32 omzetPos = rdrBrouwers.GetOrdinal("Omzet");
                            Int32? omzet;
                            while (rdrBrouwers.Read())
                            {
                                if (rdrBrouwers.IsDBNull(omzetPos))
                                {
                                    omzet = null;
                                }
                                else
                                {
                                    omzet = rdrBrouwers.GetInt32(omzetPos);
                                }
                                var brnr = rdrBrouwers.GetInt32(brouwerNrPos);
                                var brnaam = rdrBrouwers.GetString(brNaamPos);
                                var bradres = rdrBrouwers.GetString(adresPos);
                                var brpost = rdrBrouwers.GetInt16(postcodePos);
                                var brgemeente = rdrBrouwers.GetString(gemeentePos);



                                brouwers.Add(new Brouwer(brnr, brnaam, bradres, brpost, brgemeente, omzet));

                            } // do while

                        } // using rdrBrouwers
                    } // using comBrouwers
                } // using conBieren
            
            return brouwers;
        }
       


        //functie om de brouwers die men wil verwijderen effectief uit de database te verwijderen


        public void SchrijfVerwijderingen(List<Brouwer> brouwers)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comDelete = conBieren.CreateCommand())
                {
                    comDelete.CommandType=CommandType.Text;
                    comDelete.CommandText = "DELETE from brouwers where brouwerNr=@brouwerNr";
                    var parBrouwerNr = comDelete.CreateParameter();
                    parBrouwerNr.ParameterName = "@brouwerNr";
                    comDelete.Parameters.Add(parBrouwerNr);
                    conBieren.Open();
                    foreach (var brouwer in brouwers)
                    {
                        parBrouwerNr.Value = brouwer.BrouwerNr;
                        comDelete.ExecuteNonQuery();
                    }
                }
            }
        }

        //functie om de brouwers die men wil toevoegen effectief toe te voegen aan de database

        public void SchrijfToevoegingen(List<Brouwer> brouwers)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comInsert = conBieren.CreateCommand())
                {
                    comInsert.CommandType=CommandType.Text;
                    comInsert.CommandText = "Insert into Brouwers(BrNaam,Adres,PostCOde,Gemeente,Omzet)values (@brnaam,@adres,@postcode,@gemeente,@omzet)";

                    var parBrNaam = comInsert.CreateParameter();
                    parBrNaam.ParameterName = "@brnaam";
                    comInsert.Parameters.Add(parBrNaam);

                    var parAdres = comInsert.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    comInsert.Parameters.Add(parAdres);

                    var parPostCode = comInsert.CreateParameter();
                    parPostCode.ParameterName = "@postcode";
                    comInsert.Parameters.Add(parPostCode);

                    var parGemeente = comInsert.CreateParameter();
                    parGemeente.ParameterName = "@gemeente";
                    comInsert.Parameters.Add(parGemeente);

                    var parOmzet = comInsert.CreateParameter();
                    parOmzet.ParameterName = "@omzet";
                    comInsert.Parameters.Add(parOmzet);
                    conBieren.Open();

                    foreach (Brouwer brouwer in brouwers)
                    {
                        parBrNaam.Value = brouwer.BrNaam;
                        parAdres.Value = brouwer.Adres;
                        parPostCode.Value = brouwer.Postcode;
                        parGemeente.Value = brouwer.Gemeente;

                        if (brouwer.Omzet.HasValue)
                        {
                            parOmzet.Value = brouwer.Omzet;
                        }
                        else parOmzet.Value = DBNull.Value;
                        comInsert.ExecuteNonQuery();
                    }
                    
                }
            }
        }
        //wijzigingen aan de lijst doorvoeren aan de database

        public void SchrijfWijzigingen(List<Brouwer> brouwers)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comUpdate = conBieren.CreateCommand())
                {
                    comUpdate.CommandType = CommandType.Text;
                    comUpdate.CommandText =
                        "Update Brouwers set BrNaam=@brnaam, Adres=@adres, PostCode=@postcode,Gemeente=@gemeente,Omzet=@omzet Where BrouwerNr=@brouwernr";

                    var parBrNaam = comUpdate.CreateParameter();
                    parBrNaam.ParameterName = "@brnaam";
                    comUpdate.Parameters.Add(parBrNaam);

                    var parAdres = comUpdate.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    comUpdate.Parameters.Add(parAdres);

                    var parPostCode = comUpdate.CreateParameter();
                    parPostCode.ParameterName = "@postcode";
                    comUpdate.Parameters.Add(parPostCode);

                    var parGemeente = comUpdate.CreateParameter();
                    parGemeente.ParameterName = "@gemeente";
                    comUpdate.Parameters.Add(parGemeente);

                    var parOmzet = comUpdate.CreateParameter();
                    parOmzet.ParameterName = "@omzet";
                    comUpdate.Parameters.Add(parOmzet);
                    conBieren.Open();

                    var parBrouwerNr = comUpdate.CreateParameter();
                    parBrouwerNr.ParameterName = "@brouwernr";
                    comUpdate.Parameters.Add(parBrouwerNr);

                    foreach (Brouwer eenBrouwer in brouwers)
                    {
                        parBrNaam.Value = eenBrouwer.BrNaam;
                        parAdres.Value = eenBrouwer.Adres;
                        parPostCode.Value = eenBrouwer.Postcode;
                        parGemeente.Value = eenBrouwer.Gemeente;
                        if (eenBrouwer.Omzet.HasValue)
                        {
                            parOmzet.Value = eenBrouwer.Omzet;

                        }
                        else parOmzet.Value = DBNull.Value;
                        parBrouwerNr.Value = eenBrouwer.BrouwerNr;
                        comUpdate.ExecuteNonQuery();

                    }

                }
            }
        }

        //lijst maken van de verschillende postcodes
        public List<string> getPostcodes()
        {
            List<string> postnummers = new List<string>();
            var manager = new BierenDbManager();
            using (var conBrouwer = manager.GetConnection())
            {
                using (var comPostcodes = conBrouwer.CreateCommand())
                {
                    comPostcodes.CommandType=CommandType.StoredProcedure;
                    comPostcodes.CommandText = "PostCodes";
                    conBrouwer.Open();
                    using (var rdrPostcodes = comPostcodes.ExecuteReader())
                    {
                        Int32 postCodePos = rdrPostcodes.GetOrdinal("PostCode");
                        while (rdrPostcodes.Read())
                        {
                            postnummers.Add(rdrPostcodes.GetInt16(postCodePos).ToString());
                        }
                    }
                }
            }
            return postnummers;
        }
    }

}