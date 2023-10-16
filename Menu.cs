using SignalProject.Models;
using SignalProject.Models.Enum;
using SignalProject.Services;

namespace SignalProject
{
	public class Menu
	{
		private ManagementSignals MSignals = new();
		private SignalCalculations SignalCalculation = new();

		public void TextMainMenu()
		{
			Console.WriteLine("--- APLICACION DE SEÑALES ---");
			Console.WriteLine("1. Añadir Señal");
			Console.WriteLine("2. Añadir Registro Señal");
			Console.WriteLine("3. Borrar Señal");
			Console.WriteLine("4. Buscar Señal");
			Console.WriteLine("5. Media Registro Señales");
			Console.WriteLine("6. Maximo Registro Señales");
			Console.WriteLine("7. Numero Abierto y Cerrado");
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
			int canSelect;

            switch (select)
			{
				case 1:
					Signal signalCreation = ReadTypeSignal();
					if (signalCreation  != null)
					{
						MSignals.AddSignal(signalCreation);
					}
					else
					{
						Console.WriteLine("La Señal ya existe...");
					}
					break;
				case 2:
					canSelect = showSignalList();
					if (canSelect != 0)
					{
						MSignals.AddValueSignal(canSelect);
					}
					else
					{
						Console.WriteLine("No hay señales creadas...");
					}
					break;
				case 3:
					canSelect = showSignalList();
					if (canSelect != 0)
					{
						MSignals.DeleteSignal(canSelect);
					}
					else
					{
						Console.WriteLine("No hay señales creadas...");
					}
					break;
				case 4:
					ShowFindMenu();
					break;
				case 5:
                    name = Helper.readSignal();
                    double average = SignalCalculation.AverageValues(MSignals.FindSignal(name));
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
                     Console.WriteLine("El valor maximo de la señal de "+name+" es: "+ SignalCalculation.MaxValue(MSignals.FindSignal(name)));
					 break;
				case 7:
					Dictionary<String, int> OpenCloseList;
					name = Helper.readSignal();
					if (MSignals.FindSignal(name) != null && MSignals.FindSignal(name).Type.ToString() == "Digital")
					{
						OpenCloseList = SignalCalculation.NumOpenCloseSwitch(MSignals.FindSignal(name));
						Console.WriteLine($"El numero de veces que se ha encendido y apagado de la señal{name} es: Encendido: {OpenCloseList["open"]} Apagado: {OpenCloseList["close"]}");
					}
					else
					{
						Console.WriteLine("La señal no es de tipo digital");
					}
					break;

			}
		}

        public Signal ReadTypeSignal()
        {
            int cont = 1;
            int select;
            Signal signal = null;

            Dictionary<int, ESignalType> signalTypes = new Dictionary<int, ESignalType>
			{
				{ 1, ESignalType.Analog },
				{ 2, ESignalType.Digital }
			};

            Console.WriteLine("Elija el tipo de señal:");
            foreach (var signalType in signalTypes)
            {
                Console.WriteLine($"{cont}. {signalType.Value}");
                cont++;
            }
            select = Helper.ReadNum();

            if (select >= cont || select <= 0)
            {
                ReadTypeSignal();
            }
            else
            {
                Console.WriteLine("Ingrese el nombre de la señal:");
                string signalName = Helper.readSignal();

                if (!MSignals.IsCreatedSignal(signalName))
                {
                    ESignalType signalType = signalTypes[select];
                    signal = signalType == ESignalType.Analog
                        ? new AnalogSignal(signalName, ESignalType.Analog)
                        : new DigitalSignal(signalName, ESignalType.Digital);
                }
            }
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
		public int showSignalList()
		{
			int count = 1;
			int select;
			if(MSignals.SignalsList.Count > 0)
			{
				foreach (var item in MSignals.SignalsList)
				{
					Console.WriteLine($"{count}. Nombre: {item.name} Tipo: {item.Type} Fecha Creacion: {item.CreationTime}");
					count++;
				}
				select = Helper.ReadNum();

				if (select >= count || select < 1)
				{
					showSignalList();
				}

				return select;
			}
			else
			{
				return 0;
			}
			
		}
	}
}
