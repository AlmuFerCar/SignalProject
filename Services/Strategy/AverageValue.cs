using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services.Strategy
{
	public class AverageValue : IStrategy
	{
		public object DoAlgorithm(object data)
		{
			double sumValues = 0;
			int totalValues = 0;
			double average = 0;

			var Signal = data as Signal;

			foreach (var item in Signal.Values)
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
	}
}
