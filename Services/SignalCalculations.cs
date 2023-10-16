using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
	public class SignalCalculations
	{
		private IStrategy _strategy;

		public SignalCalculations()
		{ }

		public SignalCalculations(IStrategy strategy)
		{
			this._strategy = strategy;
		}

		public void SetStrategy(IStrategy strategy)
		{
			this._strategy = strategy;
		}


		public Object DoSomeBusinessLogic(Signal signal)
		{
			var result = this._strategy.DoAlgorithm(signal);

			return result;

		}

		public Dictionary<String, int> NumOpenCloseSwitch(Signal signal)
		{
			Dictionary<String, int> OpenCloseList = new Dictionary<String, int>();
			int open = 0;
			int close = 0;

			foreach (Value value in signal.Values)
			{
				if (value.NumberValue == 1)
				{
					open++;
				}
				else
				{
					close++;
				}
			}

			OpenCloseList.Add("open", open);
			OpenCloseList.Add("close", close);

			return OpenCloseList;
		}
	}
}
