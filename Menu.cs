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
	public class Menu
	{
		private ManagementSignals MSignals = new();
		public void TextMainMenu()
		{
			Console.WriteLine("--- APLICACION DE SEÑALES ---");
			Console.WriteLine("1. Añadir Señal");
			Console.WriteLine("2. Añadir Registro Señal");
			Console.WriteLine("3. Borrar Señal");
			Console.WriteLine("4. Buscar Señal"); // dos opciones --> busqueda por nombre y por tiempo
			Console.WriteLine("5. Media Registro Señales");
			Console.WriteLine("6. Maximo Registro Señales");
			Console.WriteLine("0. Salir");
		}

		public void ShowMainMenu()
		{
			int select;
			TextMainMenu();
			select = Helper.ReadNum();
			RunMainMenu(select);
			
			if(select != 0)
			{
				ShowMainMenu();
			}
		}

		public void RunMainMenu(int select)
		{
			String name;

            switch (select)
			{
				case 1:
					MSignals.AddSignal(ReadTypeSignal());
					break;
				case 2:
					MSignals.AddValueSignal();
					break;
				case 3:
					MSignals.DeleteSignal();
					break;
				case 4:
					ShowFindMenu();
					break;
				case 5:
                    name = Helper.readSignal();
                    MSignals.AverageValues(MSignals.FindSignal(name));
					break;
				case 6:
                     name = Helper.readSignal();
                    Console.WriteLine("El valor maximo de la señal de "+name+" es: "+MSignals.MaxValue(MSignals.FindSignal(name)));
					break;
			}
		}

		public Signal ReadTypeSignal()
		{
			int cont = 1;
			int select;
			Signal signal = null;

			Console.WriteLine("Que senal quieres anadir:");
			foreach (ESignalName name in ESignalName.GetValues(typeof(ESignalName)))
			{
				Console.WriteLine(cont + ". " + name);
				cont++;
			}
			select = Helper.ReadNum();

			if(select >= cont || select <= 0)
			{
				ReadTypeSignal();
			}

			switch (select)
			{
				case 1:
					signal = new ContinuousSignal(ESignalName.Temperature, ESignalType.Continuous);
					break;
				case 2:
					signal = new DiscreetSignal(ESignalName.Switch, ESignalType.Discreet);
					break;
				case 3:
					signal = new ContinuousSignal(ESignalName.Volume, ESignalType.Continuous);
					break;
				case 4:
					signal = new ContinuousSignal(ESignalName.Pressure, ESignalType.Continuous);
					break;
			}

			return signal;
		}

		public void TextFindMenu()
		{
			Console.WriteLine("--- BUSQUEDA SEÑAL ---");
			Console.WriteLine("1. Nombre");
			Console.WriteLine("2. Fecha");
			Console.WriteLine("0. Salir");
		}
		public void ShowFindMenu()
		{
			int select;
			TextFindMenu();
			select = Helper.ReadNum();

            RunFindMenu(select);

            if (select != 0)
			{
				ShowFindMenu();
			}
		}
		public void RunFindMenu(int select)
		{
			switch(select)
			{
				case 1:
					String name = Helper.readSignal();
					MSignals.ShowSignal(MSignals.FindSignal(name));
					break;
				case 2:
                    MSignals.ShowSignal(MSignals.FindSignal(DateTime.UtcNow));
					break;
			}

		}
	}
}
