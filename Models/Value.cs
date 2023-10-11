using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models.Interfaces;

namespace SignalProject.Models
{
	public class Value
	{
        public Double NumberValue { get; set; }
        public DateTime Date { get; set; }

		public Value(double numberValue)
		{
			NumberValue = numberValue;
			Date = DateTime.UtcNow;
		}
	}
}
