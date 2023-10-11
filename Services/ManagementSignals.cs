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
    public class ManagementSignals : IManagementSignals
    {
        #region -------------------------- VARIABLES ZONE --------------------------------
		private List<Signal> SignalsList = new();
		private FileSignal FileSignal = new();
        #endregion

        #region -------------------------- METHODS ZONE --------------------------------

        public bool AddSignal(Signal Signal)
        {
			try
			{
				SignalsList.Add(Signal);
				SaveSignal(SignalsList);
				return true;
			}
			catch (Exception)
			{
				return false;
			}	
		}

		public double AverageValues()
		{
            double sumValues = 0;
            int totalValues = 0;
			double average = 0;

            foreach (var signal in SignalsList)
            {
				
            }

            if (totalValues > 0)
            {
                average = sumValues / totalValues;
                Console.WriteLine("La media de todos los valores de todas las señales es: " + average);
            }
            else
            {
                Console.WriteLine("No hay valores en las señales para calcular la media.");
            }

			return average;
        }

		public bool DeleteSignal(String Name)
		{
			try
			{
				SignalsList = SignalsList.FindAll(signal => signal.name.ToString() != Name);
				SaveSignal(SignalsList);
				return true;
			}
			catch (Exception)
			{
				return false;
			}			
		}

		public Signal FindSignal(DateTime date)
		{
			return null;
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

		public int MaxValue()
		{
            ESignalName nameSignalMaxValue;
			double maxValueSignal = 0;
            DateTime dateSignalMaxValue;

            foreach (var signal in SignalsList)
            {
                if (signal is ContinuousSignal continuousSignal)
                {
                    foreach (var value in continuousSignal.Values)
                    {
                        if (value.NumberValue > maxValueSignal)
                        {
                            maxValueSignal = value.NumberValue;
                            nameSignalMaxValue = continuousSignal.name;
                        }
                    }
                }
                else if (signal is DiscreetSignal discreetSignal)
                {
                    foreach (var value in discreetSignal.Values)
                    {
                        if (value.NumberValue > maxValueSignal)
                        {
                            maxValueSignal = value.NumberValue;
                            nameSignalMaxValue = signal.name;
                        }
                    }
                }
            }
			return 0;
        }

		public bool SaveSignal(List<Signal> SignalList)
		{
			return FileSignal.InsertSignal(SignalList);
		}

		#endregion
	}
}
