using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus
{
    public class Music : Item
    {
        public string Singer { get; set; }
        public int DurationSong { get; set; }
        public Music (string naam, int code,string category,int size,string singer,int durationsong):base(naam,code,category,size)
        {
            this.Singer = singer;
            this.DurationSong = durationsong;
        }

        public void Play();
        
    }
}
