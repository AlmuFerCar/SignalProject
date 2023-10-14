using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio4List;
using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Models.Interfaces;
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
			Console.WriteLine("4. Buscar Señal");
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
                    double average = MSignals.AverageValues(MSignals.FindSignal(name));
                    if (average > 0)
					{
                        Console.WriteLine($"La media de los valores de la señal {name} es: {average}");
                    }
					else
					{
                        Console.WriteLine($"La señal {name} no tiene ningún registro de valores calcular la media.");
                    }
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

            Dictionary<int, (string name, ESignalType type)> signalTypes = new Dictionary<int, (string, ESignalType)>
			{
				{ 1, ("Temperature", ESignalType.Continuous) },
				{ 2, ("Switch", ESignalType.Discreet) },
				{ 3, ("Volume", ESignalType.Continuous) },
				{ 4, ("Pressure", ESignalType.Continuous) }
			};

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
            if (signalTypes.ContainsKey(select))
            {
                var (signalName, signalType) = signalTypes[select];

                if (MSignals.CreatedSignal(signalName))
                {
                    Console.WriteLine($"La señal de {signalName} ya está creada, puede añadir registros si lo desea");
                }
                else
                {
                    signal = signalType == ESignalType.Continuous
                        ? new ContinuousSignal((ESignalName)Enum.Parse(typeof(ESignalName), signalName), ESignalType.Continuous)
                        : new DiscreetSignal((ESignalName)Enum.Parse(typeof(ESignalName), signalName), ESignalType.Discreet);
                }
            }

            //switch (select)
            //{
            //	case 1:
            //		if (MSignals.CreatedSignal("Temperature"))
            //		{
            //			Console.WriteLine("La señal de temperatura ya está creada, puede añadir registros si lo desea");
            //		}
            //		else
            //		{
            //                     signal = new ContinuousSignal(ESignalName.Temperature, ESignalType.Continuous);
            //                 }
            //		break;
            //	case 2:
            //                 if (MSignals.CreatedSignal("Switch"))
            //                 {
            //                     Console.WriteLine("La señal del interruptor ya está creada, puede añadir registros si lo desea");
            //                 }
            //                 else
            //                 {
            //                     signal = new DiscreetSignal(ESignalName.Switch, ESignalType.Discreet);
            //                 }
            //		break;
            //	case 3:
            //                 if (MSignals.CreatedSignal("Volume"))
            //                 {
            //                     Console.WriteLine("La señal de Volumen ya está creada, puede añadir registros si lo desea");
            //                 }
            //                 else
            //                 {
            //                     signal = new ContinuousSignal(ESignalName.Volume, ESignalType.Continuous);
            //                 }
            //		break;
            //	case 4:
            //                 if (MSignals.CreatedSignal("Pressure"))
            //                 {
            //                     Console.WriteLine("La señal de presión ya está creada, puede añadir registros si lo desea");
            //                 }
            //                 else
            //                 {
            //                     signal = new ContinuousSignal(ESignalName.Pressure, ESignalType.Continuous);
            //                 }
            //		break;
            //}
            return signal;
		}

		public void TextFindMenu()
		{
			Console.WriteLine("--- BUSQUEDA SEÑAL ---");
			Console.WriteLine("1. Por Nombre");
			Console.WriteLine("2. Por Fecha");
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
					Console.Write("DÍA: ");
                    int day = Helper.ReadNum();
                    Console.Write("MES: ");
                    int month = Helper.ReadNum();
                    Console.Write("AÑO: ");
                    int year = Helper.ReadNum();
                    DateTime fechaBusqueda = new DateTime(year, month, day);

					foreach (String listSIgnalDate in MSignals.FindSignal(fechaBusqueda))
					{ 
						Console.WriteLine($"{listSIgnalDate}");
					}
					break;
			}

		}
	}
}
