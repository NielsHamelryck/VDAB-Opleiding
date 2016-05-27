using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CSharpPFOefenmap
{
    
    public class Twitter
    {
        const string twitterbestand = @"C:\Data\Twitter.obj";

        // alle tweets in omgekeerde chronologische volgorde
        public List<Tweet> AlleTweets()
        {
            if (File.Exists(twitterbestand))
            {
                var tweets = LeesTweets();
                return tweets.AlleTweets().OrderByDescending(t => t.Tijdstip).ToList();
            }
            else
                throw new Exception("Het bestand " + twitterbestand + " is niet gevonden");
        }
        // alle Tweets van een twitteraar

        public List<Tweet> TweetVan(string naam)
        {
            return AlleTweets().Where(t => t.Naam.ToUpper() == naam.ToUpper()).ToList();

        }

        // een tweet toevoegen
        public void SchrijfTweet(Tweet tweet)
        {
            Tweets tweets;
            if (File.Exists(twitterbestand))
            {
                //als het bestand bestaat
                //eerst de verzameling van bestaande tweets inlezen
                tweets = leesTweets();
            }
            else tweets = new Tweets();
            tweets.AddTweet(tweet);
        }
    }
}
