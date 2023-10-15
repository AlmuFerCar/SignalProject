using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models.Interfaces
{
    public interface IFileSignal
    {
        public List<Signal> FindAllSignals();
        public bool InsertSignal(List<Signal> SignalList);
    }
}
