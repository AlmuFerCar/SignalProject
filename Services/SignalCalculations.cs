using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Enum;

namespace SignalProject.Services
{
	public class SignalCalculations
	{
		public double AverageValues(Signal signal)
		{
			double sumValues = 0;
			int totalValues = 0;
			double average = 0;

			foreach (var item in signal.Values)
			{
				sumValues += item.NumberValue;
				totalValues++;
			}

			if (totalValues > 0)
			{
				average = sumValues / totalValues;
			}
			return average;
		}
		public double MaxValue(Signal signal)
		{
			ESignalName nameSignalMaxValue;
			double maxValueSignal = 0;
			DateTime dateSignalMaxValue;

			foreach (var itemSignal in signal.Values)
			{
				if (itemSignal.NumberValue > maxValueSignal)
				{
					maxValueSignal = itemSignal.NumberValue;
				}
			}
			return maxValueSignal;
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
