using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio4List
{
    public class Helper
    {
        public int ReadNum()
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
        public String readSignal()
        {
            Regex rgx = new Regex(@"\b[A-Za-z]+\b");
            String value;
            Console.WriteLine("Escribe una senial");
			value = Console.ReadLine();

            if (!rgx.IsMatch(value))
            {
				readSignal();
            }

            return value;
        }
    }
}
