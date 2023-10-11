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
		private List<Value> values;
		public ContinuousSignal(ESignalName SignalName, ESignalType signalType) : base(SignalName, signalType)
		{
			this.values = new List<Value>();
		}

        public List<Value> Values { get => values; set => values = value; }
    }
}
