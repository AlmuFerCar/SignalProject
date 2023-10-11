using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
    public class FileSignal : IFileSignal
    {
		private string path = @"C:\Users\iscastro\Desktop\Signals.txt";
		//private String path = "";

		public List<Signal> FindAllSignals()
        {
			List<Signal> Signals = new();
			String[] FileList;
			ESignalName eSignalName;
			ESignalType eSignalType;
			String[] ValuesList;

			ContinuousSignal continuousSignal;

			using (StreamReader sr = File.OpenText(path))
			{
				string s;
				while ((s = sr.ReadLine()) != null)
				{
					FileList = s.Split('-');
					Enum.TryParse(FileList[0], out eSignalName);
					Enum.TryParse(FileList[1], out eSignalType);
					continuousSignal = new ContinuousSignal(eSignalName, eSignalType, DateTime.UtcNow);
					ValuesList = FileList[3].Split(";");

					for(int i = 0; i < ValuesList.Length; i++)
					{
						if (ValuesList[i] != "")
						{
	
							continuousSignal.Values.Add(new Value(Convert.ToDouble(ValuesList[i].Split("*")[0]), DateTime.UtcNow));
						}
					}

					Signals.Add(continuousSignal);
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
				String values = "";
				using (StreamWriter sw = File.CreateText(path))
				{
					foreach (Signal signal in SignalList)
					{
						if (signal != null)
						{
							signal.Values.ForEach(value => { values += value.NumberValue + " * " + value.Date.ToString() + ";"; });
							sw.Write($"{signal.name} - {signal.Type} - {signal.CreationTime} - {values}{Environment.NewLine}");
							values = "";
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
