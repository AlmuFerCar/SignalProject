using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models.Interfaces
{
    public interface IManagementSignals
    {
        public bool AddSignal(Signal Signal);
        public bool DeleteSignal();
        public bool SaveSignal(List<Signal> SignalList);
        public double MaxValue(Signal signal);
        public double AverageValues(Signal signal);
        public Signal FindSignal(DateTime date);
        public Signal FindSignal(string name);
    }
}
