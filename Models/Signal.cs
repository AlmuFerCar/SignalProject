using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Enum;

namespace SignalProject.Models
{
    public abstract class Signal
    {
        public ESignalName name { get; set; }
        public ESignalType Type { get; set; }
        public DateTime CreationTime { get; set; }


        public Signal(ESignalName SignalName , ESignalType signalType)
        {
            this.name = SignalName;
            this.Type = signalType;
            this.CreationTime = DateTime.Now;
        }


        public override bool Equals(object? obj)
        {
            return obj is Signal signal &&
                   name == signal.name;
        }
        public override string ToString()
        {
            return name.ToString();
        }
    }
}
