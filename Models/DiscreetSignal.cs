using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models
{
    public class DiscreetSignal : Signal
    {
        List<int> Values { get; set; }

        public DiscreetSignal()
        {
            Values = new();
        }
    }
}
