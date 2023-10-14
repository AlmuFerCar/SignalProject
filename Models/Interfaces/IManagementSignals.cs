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
        public bool DeleteSignal(int select);
        public bool SaveSignal(List<Signal> SignalList);
        public double MaxValue(Signal signal);
        public double AverageValues(Signal signal);
        public List<String> FindSignal(DateTime date);
        public Signal FindSignal(string name);
        public void AddValueSignal(int select);
		public bool IsCreatedSignal(string name);
        public Dictionary<String, int> NumOpenCloseSwitch(Signal signal);
    }
}
