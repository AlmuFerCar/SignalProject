﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ejercicio4List;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
    public class ManagementSignals : IManagementSignals
    {
		#region -------------------------- VARIABLES ZONE --------------------------------
		public List<Signal> SignalsList { get; }
		private FileSignal FileSignal = new();
        #endregion

		public ManagementSignals() 
		{ 
			this.SignalsList = FileSignal.FindAllSignals();
		}

        #region -------------------------- METHODS ZONE --------------------------------

        public bool AddSignal(Signal Signal)
        {
			try
			{
				if (Signal != null)
				{
					SignalsList.Add(Signal);
					SaveSignal(SignalsList);
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}	
		}

		public double AverageValues(Signal signal)
		{
            double sumValues = 0;
            int totalValues = 0;
			double average = 0;

            foreach (var item in signal.Values)
            {
				sumValues += item.NumberValue;
				totalValues++;
            }

            if (totalValues > 0)
            {
                average = sumValues / totalValues;
            }
			return average;
        }

		public bool DeleteSignal(int select)
		{
			try
			{
				Signal signal;
				SignalsList.RemoveAt(select - 1);
				SaveSignal(SignalsList);
				return true;
			}
			catch (Exception)
			{
				return false;
			}			
		}

		public List<String> FindSignal(DateTime date)
		{
			List<String> SignalsByDate = new List<String>();
            foreach (var signals in SignalsList)
            {
                foreach (var values in signals.Values)
                {
                    if (values.Date.Date == date.Date)
                    {
						SignalsByDate.Add("Señal: "+signals+Environment.NewLine +"Fecha del registro: "+values.Date+ " con valor: "+values.NumberValue);
                    }
                }
            }
			return SignalsByDate;
        }

		public Signal FindSignal(string name)
		{
			Signal signal;
			try
			{
				signal = SignalsList.Find(signal => signal.name.ToString() == name);
				return signal;
			}
			catch (Exception)
			{
				return null;
			}			 
		}

		public double MaxValue(Signal signal)
		{
            ESignalName nameSignalMaxValue;
			double maxValueSignal = 0;
            DateTime dateSignalMaxValue;

            foreach (var itemSignal in signal.Values)
            {
				if (itemSignal.NumberValue > maxValueSignal)
				{ 
					maxValueSignal = itemSignal.NumberValue;
				}
            }
			return maxValueSignal;
        }

		public bool SaveSignal(List<Signal> SignalList)
		{
			return FileSignal.InsertSignal(SignalList);
		}

		public void AddValueSignal(int select)
		{
			Signal signal;

			signal = SignalsList.ElementAt((select-1));

			if( signal.Type == ESignalType.Continuous)
			{
				signal.Values.Add(new Value(Helper.ReadNumDouble()));
			}
			else
			{
				signal.Values.Add(new Value(Helper.ReadNumBit()));
			}

			SignalsList.RemoveAt(select-1);
			SignalsList.Add(signal);
			FileSignal.InsertSignal(SignalsList);
		}

		public void ShowSignal(Signal signal)
		{
			Console.Clear();
			if (signal == null)
			{
				Console.WriteLine("No existe esta señal");
			}
			else
			{
                Console.WriteLine($"Señal de: {signal.name} es de tipo: {signal.Type} su fecha de creación es: {signal.CreationTime}");
				if (signal.Values.Count > 0)
				{
                    Console.WriteLine("con valores: ");
                    foreach (var item in signal.Values)
                    {
                        Console.WriteLine($"Valor: {item.NumberValue} Fecha: {item.Date}");
                    }
				}
				else
				{
					Console.WriteLine("No hay valores añadidos...");
				}
            }
		}

		public bool IsCreatedSignal(string name)
		{
			bool signalIsCreated = false;
            foreach (Signal itemSignal in SignalsList)
            {
				if (itemSignal.name.ToString() == name)
				{ 
					signalIsCreated = true;
				}
            }
            return signalIsCreated;
		}

		public Dictionary<String,int> NumOpenCloseSwitch(Signal signal)
		{
			Dictionary<String, int> OpenCloseList = new Dictionary<String, int>();
			int open = 0;
			int close = 0;	

			foreach (Value value in signal.Values)
			{
				if (value.NumberValue == 1)
				{
					open++;
				}
				else
				{
					close++;
				}
			}

			OpenCloseList.Add("open", open);
			OpenCloseList.Add("close", close);

			return OpenCloseList;
		}

		#endregion
	}
}
