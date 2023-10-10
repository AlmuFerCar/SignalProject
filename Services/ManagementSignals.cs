using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalProject.Models;
using SignalProject.Models.Interfaces;

namespace SignalProject.Services
{
    public class ManagementSignals : IManagementSignals
    {
        #region -------------------------- VARIABLES ZONE --------------------------------
        List<Signal> SignalsList = new();
        #endregion

        #region -------------------------- METHODS ZONE --------------------------------

        public bool AddSignal()
        {
            throw new NotImplementedException();
        }

        public double AverageValues()
        {
            throw new NotImplementedException();
        }

        public bool DeleteSignal()
        {
            throw new NotImplementedException();
        }

        public Signal FindSignal(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Signal FindSignal(string name)
        {
            throw new NotImplementedException();
        }

        public int MaxValue()
        {
            throw new NotImplementedException();
        }

        public bool SaveSignal(Signal signal)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
