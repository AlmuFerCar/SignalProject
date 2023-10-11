using System;
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
                Console.WriteLine("La media de todos los valores de todas las señales es: " + average);
            }
            else
            {
                Console.WriteLine("No hay valores en las señales para calcular la media.");
            }

			return average;
        }

		public bool DeleteSignal()
		{
			try
			{
				int count = 1;
				int select;
				Signal signal;

				foreach (var item in SignalsList)
				{
					Console.WriteLine($"{count}. Nombre: {item.name.ToString()} Tipo: {item.Type} Fecha Creacion: {item.CreationTime}");
					count++;
				}
				select = Helper.ReadNum();

				if (select >= count || select < 1)
				{
					DeleteSignal();
				}

				SignalsList.RemoveAt(select - 1);
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
			//Signal signal;
			//         try
			//         {
			//             signal = SignalsList.Find(signal => signal.name.ToString() == date);
			//             return signal;
			//         }
			//         catch (Exception)
			//         {
			//             return null;
			//         }
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

		public void AddValueSignal()
		{
			int count = 1;
			int select;
			Signal signal;

            foreach (var item in SignalsList)
            {
				Console.WriteLine($"{count}. Nombre: {item.name.ToString()} Tipo: {item.Type} Fecha Creacion: {item.CreationTime}");
				count++;
            }
			select = Helper.ReadNum();

			if (select >= count || select < 1)
			{
				AddValueSignal();
			}

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
			if (signal == null)
			{
				Console.WriteLine("No existe esta señal");
			}
			else
			{
                Console.WriteLine($"Señal de: {signal.name} es de tipo: {signal.Type} su fecha de creación es: {signal.CreationTime}");
                Console.WriteLine("con valores: ");
                foreach (var item in signal.Values)
                {
                    Console.WriteLine($"Valor: {item.NumberValue} Fecha: {item.Date}");
                }
            }
		}
		#endregion
	}
}
