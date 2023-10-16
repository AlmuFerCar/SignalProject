using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SignalProject.Models
{
    public class AnalogSignal : Signal
    {
		public AnalogSignal(string SignalName, ESignalType signalType) : base(SignalName, signalType)
		{
			Values = new List<Value>();
		}
		public AnalogSignal(string SignalName, ESignalType signalType, DateTime date) : base(SignalName, signalType, date)
		{
			Values = new List<Value>();
		}
	}
}
