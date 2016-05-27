using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharpPFOefenmap
{   
    [Serializable]
    public class Tweets
    {
        private List<Tweet> alleTweetValue;
       
        public ReadOnlyCollection<Tweet> AlleTweets()
        {
            return new ReadOnlyCollection<Tweet>(alleTweetValue);
        }

        public void AddTweet(Tweet tweet)
        {
            if (alleTweetValue == null)
                alleTweetValue = new List<Tweet>();
            alleTweetValue.Add(tweet);
        }

    }
}
