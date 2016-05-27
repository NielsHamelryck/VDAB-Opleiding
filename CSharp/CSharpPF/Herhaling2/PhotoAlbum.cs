using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class PhotoAlbum
    {
        private int numberOfPages;

        public int GetNumberOFPages
        {
            get { return numberOfPages; }
            private set { numberOfPages = value; }
        }
        

        public PhotoAlbum()
        {
            GetNumberOFPages = 16;
        }
        public PhotoAlbum(int pages)
        {
            this.GetNumberOFPages = pages;
        }
    }
}
