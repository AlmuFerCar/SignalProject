using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;

namespace SignalProject.Models
{
    public class DiscreetSignal : Signal
    {	
		List<int> Values { get; set; }

		public DiscreetSignal(ESignalName SignalName, ESignalType signalType) : base(SignalName, signalType)
		{
			this.Values = new();
		}



	}
}
