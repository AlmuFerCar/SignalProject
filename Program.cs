using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio4List;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Services;

namespace SignalProject
{
	public class Program
	{
		public static void Main(string[] args) 
		{
			
			//FileSignal file = new FileSignal();

			//List<Signal> list = file.FindAllSignals();

			Menu menu = new Menu();
			menu.ShowMainMenu();
		}
	}
}
