using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models.Interfaces
{
    public interface IManagementSignals
    {
        public bool AddSignal();
        public bool DeleteSignal();
        public bool SaveSignal(Signal signal);
        public int MaxValue();
        public double AverageValues();
        public Signal FindSignal(DateTime date);
        public Signal FindSignal(string name);
    }
}
