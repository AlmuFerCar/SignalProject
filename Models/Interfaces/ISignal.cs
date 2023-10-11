using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProject.Models.Interfaces
{
	public interface ISignal<T>
	{
		public List<T> Values { get; set; }
	}
}
