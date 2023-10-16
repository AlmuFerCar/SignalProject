using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services.Strategy
{
	internal class NumOpenClose : IStrategy
	{
		public object DoAlgorithm(object data)
		{
			Dictionary<String, int> OpenCloseList = new Dictionary<String, int>();
			int open = 0;
			int close = 0;
			var Signal = data as Signal;

			foreach (Value value in Signal.Values)
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
