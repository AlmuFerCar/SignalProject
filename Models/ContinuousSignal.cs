using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models
{
    public class ContinuousSignal : Signal
    {
        private List<double> Values { get; set; }

        public ContinuousSignal()
        {
            Values = new();
        }
    }
}
