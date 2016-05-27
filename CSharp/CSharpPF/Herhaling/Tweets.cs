using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Herhaling
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> tweetLijst;

        public ReadOnlyCollection<Tweet> TweetLijst
        {
            get { return new ReadOnlyCollection<Tweet>( tweetLijst); }
            
        }
        
        public void AddTweet(Tweet tweet)
        {
            if (tweetLijst == null)
                tweetLijst = new List<Tweet>();
            tweetLijst.Add(tweet);
        }
    }
}
