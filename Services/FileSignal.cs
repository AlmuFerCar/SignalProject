﻿using System.Text.Json;
using System.Text.Json.Serialization;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
    public class FileSignal : IFileSignal
    {

        public static string proyectoPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
        string path = Path.Combine(proyectoPath, "SignalFile.txt");

        public List<Signal> GetAllSignals()
        {
            try
            {
                List<Signal> Signals = new();
                String[] FileList;
                string SignalName;
                ESignalType eSignalType;
                String[] ValuesList;

                Signal Signal;

                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        FileList = s.Split('-');
                        SignalName = FileList[0];
                        Enum.TryParse(FileList[1], out eSignalType);

                        if (eSignalType.Equals(ESignalType.Analog))
                        {
                            Signal = new AnalogSignal(SignalName.Trim(), eSignalType, Helper.DateStringParser(FileList[2]));
                        }
                        else
                        {
                            Signal = new DigitalSignal(SignalName.Trim(), eSignalType, Helper.DateStringParser(FileList[2]));
                        }



                        ValuesList = FileList[3].Split(";");

                        for (int i = 0; i < ValuesList.Length; i++)
                        {
                            if (ValuesList[i] != " " && ValuesList[i] != "")
                            {
                                Signal.Values.Add(new Value(Convert.ToDouble(ValuesList[i].Split("*")[0]), Helper.DateStringParser(ValuesList[i].Split("*")[1])));
                            }
                        }

                        Signals.Add(Signal);
                    }
                }

                if (Signals == null) Signals = new();

				return Signals;
			}
			catch (FileNotFoundException)
			{
				return new List<Signal>();
			}
			catch (Exception)
			{

				throw;
			}
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

                            //String json = JsonSerializer.Serialize(signal);
                            //Console.WriteLine(json+",");

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
