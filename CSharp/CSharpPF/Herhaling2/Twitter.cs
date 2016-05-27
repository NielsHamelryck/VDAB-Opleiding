using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Herhaling2
{
    public class Twitter
    {
        const string twitterbestand = @"C:\Data\twitter2.obj";
        private Tweets LeesTweets()
        {
            
            try
            {

                using (var bestand = File.Open(twitterbestand, FileMode.Open, FileAccess.Read))
                { 
                    var lezer = new BinaryFormatter();
                    var x = lezer.Deserialize(bestand);
                    return (Tweets)x; 
                }
                
            }
            catch (IOException)
            {
                throw new Exception("Fout bij het openen van het bestand");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het deserializeren");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Tweet> AlleTweetsLezen()
        {
            
            return LeesTweets().AlleTweets.OrderByDescending(tweet => tweet.Tijdstip).ToList();
        }

        public List<Tweet> TweetVan(string naam)
        {
            return AlleTweetsLezen().Where(tweet => tweet.Naam.ToUpper() == naam.ToUpper()).ToList();
        }

        public void schrijfTweet(Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(twitterbestand))
                tweets = LeesTweets();
            else tweets = new Tweets();
            tweets.addTweet(tweet);
            SchrijfTweets(tweets);
        }
        public void SchrijfTweets(Tweets tweets){
            try{
                using(var bestand = File.Open(twitterbestand,FileMode.OpenOrCreate)){
                    var schrijven = new BinaryFormatter();
                    schrijven.Serialize(bestand,tweets);
                }
            }catch(IOException)
            {
                throw new Exception("Kan het bestand niet openen");
            }catch(SerializationException){
                throw new Exception("fout bij het serialiseren");
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}
