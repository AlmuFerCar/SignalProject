using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services.Strategy
{
    public class MaxValue : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            double maxValueSignal = 0;
            var Signal = data as Signal;

            foreach (var itemSignal in Signal.Values)
            {
                if (itemSignal.NumberValue > maxValueSignal)
                {
                    maxValueSignal = itemSignal.NumberValue;
                }
            }
            return maxValueSignal;
        }
    }
}
