using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Herhaling
{
    class Program
    {


        static void Main(string[] args)
        {
            
            Twitter twitter = new Twitter();
            string titel = "Twitter";
            Console.WriteLine(titel);
            
            for (var teller = 0; teller < titel.Length; teller++) { Console.Write('*'); }
            Console.WriteLine();
            int keuze = MaakKeuze();
            while (keuze != 4)
            {
                try
                {
                    switch (keuze)
                    {
                        case 1: Console.WriteLine();
                            Console.WriteLine("Geef een gebruikersnaam");
                            var naam = Console.ReadLine();
                            Console.WriteLine("Bericht (MAX 140 tekens):");
                            var max = false;
                            while (!max)
                            {
                                var bericht = Console.ReadLine();
                                if (bericht.Length <= 140)
                                {
                                    Tweet tweet = new Tweet(naam, bericht);

                                    twitter.SchrijfTweet(tweet);
                                    max = true;
                                }
                                else
                                {
                                    Console.WriteLine("Meer als 140 tekens, probeer opnieuw");

                                }
                            }
                            break;
                        case 2: Console.WriteLine();
                            Console.WriteLine("Berichten:");
                            var tweets = twitter.AlleTweets();
                            foreach (var t in tweets)
                            {
                                Console.WriteLine(t);
                            }
                            break;
                        case 3: Console.WriteLine();
                            Console.WriteLine("Naam van degene die u wil Volgen:");
                            string gevolgde = Console.ReadLine();
                            var tweetsGevolgde = twitter.SpecifiekeTweets(gevolgde);
                            foreach (var tGevolgde in tweetsGevolgde) { Console.WriteLine(tGevolgde); }
                            break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                keuze = MaakKeuze();
            } 
                
            
        }
        private static int MaakKeuze()
        {
            Console.WriteLine("Maak een keuze");
            Console.WriteLine("---->1.Plaats een twitter bericht");
            Console.WriteLine("---->2.Lees alle twitter berichten");
            Console.WriteLine("---->3.Lees de twitter bericht van een gevolgd persoon");
            Console.WriteLine("---->4.Stoppen");
            var keuze = int.Parse(Console.ReadLine());
            if (keuze != 1 && keuze != 2 && keuze != 3 && keuze != 4)
            {
                Console.WriteLine("geen geldige keuze gemaakt kies opnieuw");
               
                
                return MaakKeuze();
            }
            else return keuze;
        }

    }






}

