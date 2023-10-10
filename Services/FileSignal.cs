using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
    public class FileSignal : IFileSignal
    {
		private string path = @"C:\Users\iscastro\Desktop\Signals.txt";
		//private String path = "";
		public List<Signal> FindAllSignals()
        {
            throw new NotImplementedException();
        }

        public Signal FindSignalByName(string name)
        {
            throw new NotImplementedException();
        }

        public Signal FindSignalByTime(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool InsertSignal(Signal signal)
        {
            throw new NotImplementedException();
        }
    }
}
