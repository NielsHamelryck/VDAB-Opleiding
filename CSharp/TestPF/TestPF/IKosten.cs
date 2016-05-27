using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    public interface IKosten
    {
        decimal maandkost
        {
            get;
        }
        void gegevensTonen();
    }
}
