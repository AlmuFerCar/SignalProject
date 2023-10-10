using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;

namespace SignalProject.Models
{
    public class ContinuousSignal : Signal
    {
		private List<double> Values { get; set; }
		public ContinuousSignal(ESignalName SignalName, ESignalType signalType) : base(SignalName, signalType)
		{
			this.Values = new List<double>();
		}
	}
}
