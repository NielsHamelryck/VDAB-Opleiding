using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Herhaling2
{
    [Serializable]
    public class Tweets
    {
        private List<Tweet> tweetValue;

        public ReadOnlyCollection<Tweet> AlleTweets
        {
            get { return new ReadOnlyCollection<Tweet>(tweetValue); }
            
        }
        
        public void addTweet(Tweet tweet){
           
            if(tweetValue==null)
                tweetValue= new List<Tweet>();
            tweetValue.Add(tweet);
        }
    }
}
