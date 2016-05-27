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
    public class Twitter
    {
        const string twitterbestand = @"C:\Data\twitter.obj";

        private Tweets LeesTweetsBestand(){
            try{
            
                using(var bestand = File.Open(twitterbestand,FileMode.Open,FileAccess.Read)){
                    var lezer = new BinaryFormatter();
                    return (Tweets)lezer.Deserialize(bestand);
                }
            }catch(IOException){ throw new Exception("Fout bij het openen van het bestand!");}
            catch(SerializationException){throw new Exception("Fout bij het deserialiseren, "+"het twitterbestand kan niet meer geopend worden");}
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
           public List<Tweet> AlleTweets(){
               
               var tweets=LeesTweetsBestand();
               
               return tweets.TweetLijst.OrderByDescending(tweet=>tweet.Tijdstip).ToList();
               
           }
            public List<Tweet> SpecifiekeTweets(string naam){
               
                    return AlleTweets().Where(t=>t.Naam.ToUpper()==naam.ToUpper()).ToList();
               
            }
            public void SchrijfTweet(Tweet tweet){
                Tweets tweets;
                if(File.Exists(twitterbestand))
                    tweets= LeesTweetsBestand();
                else tweets= new Tweets();
                tweets.AddTweet(tweet);
                SchrijfTweets(tweets);
                
            }
            private void SchrijfTweets(Tweets tweets)
            {
                try
                {
                    using (var bestand = File.Open(twitterbestand, FileMode.OpenOrCreate))
                    {
                        var schrijven = new BinaryFormatter();
                        schrijven.Serialize(bestand, tweets);
                    }
                }
                catch (IOException)
                {
                    throw new Exception("Fout bij het openen van het bestand");

                }
                catch (SerializationException)
                {
                    throw new Exception("Fout bij het Serialiseren" + "het bestand kan niet meer geopend worden");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }      
            
            

        }
        
    
