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

		// COMPLETAR
		public List<Signal> FindAllSignals()
        {
			List<Signal> Signals = new();

			using (StreamReader sr = File.OpenText(path))
			{
				string s;
				while ((s = sr.ReadLine()) != null)
				{
                   
				}
			}
			return Signals;
		}

        public Signal FindSignalByName(string name)
        {
            throw new NotImplementedException();
        }

        public Signal FindSignalByTime(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool InsertSignal(List<Signal> SignalList)
        {
			try
			{
				using (StreamWriter sw = File.CreateText(path))
				{
					foreach (Signal w in SignalList)
					{
						if (w != null)
						{
							sw.Write($"");
						}
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
    }
}
