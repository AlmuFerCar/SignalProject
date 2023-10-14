using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio4List;
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
			try
			{
				List<Signal> Signals = new();
				String[] FileList;
				ESignalName eSignalName;
				ESignalType eSignalType;
				String[] ValuesList;

				Signal Signal;

				using (StreamReader sr = File.OpenText(path))
				{
					string s;
					while ((s = sr.ReadLine()) != null)
					{
						FileList = s.Split('-');
						Enum.TryParse(FileList[0], out eSignalName);
						Enum.TryParse(FileList[1], out eSignalType);

						if(eSignalType.ToString() == "Continuous")
						{
							Signal = new ContinuousSignal(eSignalName, eSignalType, Helper.DateStringParser(FileList[2].Trim()));
						}
						else
						{
							Signal = new DiscreetSignal(eSignalName, eSignalType, Helper.DateStringParser(FileList[2].Trim()));
						}
						


						ValuesList = FileList[3].Split(";");

						for (int i = 0; i < ValuesList.Length; i++)
						{
							if (ValuesList[i] != " " && ValuesList[i] != "")
							{
								Signal.Values.Add(new Value(Convert.ToDouble(ValuesList[i].Split("*")[0]), Helper.DateStringParser(ValuesList[i].Split("*")[1].Trim())));
							}
						}

						Signals.Add(Signal);
					}
				}

				if (Signals == null)  Signals = new();

				return Signals;
			}
			catch (Exception)
			{

				throw;
			}
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
