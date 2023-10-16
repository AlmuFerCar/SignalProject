using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;

namespace SignalProject.Models
{
    public abstract class Signal
    {
        public string name { get; set; }
        public ESignalType Type { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Value> Values { get; set; }

		public Signal(string SignalName , ESignalType signalType)
        {
            this.name = SignalName;
            this.Type = signalType;
            this.CreationTime = DateTime.UtcNow;
        }

		public Signal(string SignalName, ESignalType signalType , DateTime date)
		{
			this.name = SignalName;
			this.Type = signalType;
			this.CreationTime = date;
		}

		public override string ToString()
        {
            return name.ToString();
        }

    }
}
