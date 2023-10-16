using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SignalProject.Services
{
    public class Helper
    {
        public static int ReadNum()
        {
            Regex rgx = new Regex("^[0-9]+");
            String valor;
            int numero = 0;
            Console.WriteLine("Escribe un numero");
            valor = Console.ReadLine();

            Console.Clear();

            if (rgx.IsMatch(valor))
            {
                numero = Convert.ToInt32(valor);
            }
            else
            {
                Console.WriteLine("Escribe solo numero porfavor!");
                ReadNum();
            }
            return numero;
        }
        public static int ReadNumBit()
        {
            Regex rgx = new Regex(@"\b[0|1]\b");
            String valor;
            int numero = 0;
            Console.WriteLine("Escribe 1(encendido) || 0(apagado)");
            valor = Console.ReadLine();

            Console.Clear();

            while (!rgx.IsMatch(valor))
            {
                Console.WriteLine("Entrada incorrecta. Escribe 1(encendido) || 0(apagado)");
                valor = Console.ReadLine();
                Console.Clear();
            }

            numero = Convert.ToInt32(valor);
            return numero;
        }
        public static double ReadNumDouble()
        {
            Regex rgx = new Regex("^\\d+(\\,\\d+)?$");
            String valor;
            double numero = 0;
            Console.WriteLine("Escribe un numero decimal");
            valor = Console.ReadLine();

            Console.Clear();

            while (!rgx.IsMatch(valor))
            {
                Console.WriteLine("Error: escribe solo un numero decimal");
                valor = Console.ReadLine();
                Console.Clear();
            }

            numero = Convert.ToDouble(valor);
            return numero;
        }
        public static DateTime DateStringParser(string dateString) 
        {
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture);
            return date;
        }
        public static String readSignal()
        {
            Regex rgx = new Regex(@"\b[A-Za-z]+\b");
            String value;
            Console.WriteLine("Escribe una señal");
			value = Console.ReadLine();

            if (!rgx.IsMatch(value))
            {
				readSignal();
            }

            return value;
        }
    }
}
