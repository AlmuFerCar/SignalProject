using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;

namespace SignalProject.Models
{
    public class DigitalSignal : Signal
    {
		public DigitalSignal(string SignalName, ESignalType signalType) : base(SignalName, signalType)
		{
			Values = new List<Value>();
		}

		public DigitalSignal(string SignalName, ESignalType signalType, DateTime date) : base(SignalName, signalType, date)
		{
			Values = new List<Value>();
		}
	}
}
