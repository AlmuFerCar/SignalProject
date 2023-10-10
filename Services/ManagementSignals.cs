using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public bool SaveSignal(List<Signal> SignalList)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
