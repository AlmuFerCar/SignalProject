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
			this.SignalsList = FileSignal.GetAllSignals();
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
				signal = SignalsList.Find(signal => signal.name.ToLower().Equals(name.ToLower()));
				return signal;
			}
			catch (Exception)
			{
				return null;
			}			 
		}
		public bool SaveSignal(List<Signal> SignalList)
		{
			return FileSignal.InsertSignal(SignalList);
		}
		public void AddValueSignal(int select)
		{
			Signal signal;

			signal = SignalsList.ElementAt((select-1));

			if( signal.Type == ESignalType.Analog)
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
            else if (signal.Values.Count > 0)
            {
                Console.WriteLine($"Señal de: {signal.name} es de tipo: {signal.Type} su fecha de creación es: {signal.CreationTime}");
                Console.WriteLine("con valores: ");
                foreach (var item in signal.Values)
                {
                    Console.WriteLine($"Valor: {item.NumberValue} Fecha: {item.Date}");
                }
            }
            else
            {
                Console.WriteLine($"Señal de: {signal.name} es de tipo: {signal.Type} su fecha de creación es: {signal.CreationTime}");
                Console.WriteLine("No tiene valores añadidos.");
            }
        }

        public bool IsCreatedSignal(string name)
		{
            bool signalIsCreated = SignalsList.Any(itemSignal => itemSignal.name.ToString().ToLower() == name.ToLower());
            return signalIsCreated;
		}
		#endregion
	}
}
