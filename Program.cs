using System;
using System.Collections.Generic;
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
			ManagementSignals ms = new();
			int cont = 1;
			int select;

			Console.WriteLine("Que senal quieres anadir:");
			foreach (ESignalName name in ESignalName.GetValues(typeof(ESignalName))) 
			{ 
				Console.WriteLine(cont+". "+name);
				cont++;
			}
			select = Helper.ReadNum();

			switch (select)
			{
				case 1:

					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
			}

		}
	}
}
