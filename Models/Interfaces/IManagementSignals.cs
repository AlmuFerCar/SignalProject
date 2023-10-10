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
        public bool DeleteSignal(String Name);
        public bool SaveSignal(List<Signal> SignalList);
        public int MaxValue();
        public double AverageValues();
        public Signal FindSignal(DateTime date);
        public Signal FindSignal(string name);
    }
}
