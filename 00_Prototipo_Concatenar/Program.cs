using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _00_Prototipo_Concatenar
{
    internal class Program
    {
        //INFO-103 Proyecto 1 Funciones de concatenacion.
        /*Objetivo
        Manejar un workflow para concatenar varios string en un numero y convertirlo a float or double.
        Idear una manera de implementar el boton mas menos el cual convierte el numero escrito en positivo o negativo dependiendo de su estado.
        Comprender la forma de hacer conversiones de string a double.
        Recursos: 
        https://learn.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings
        https://learn.microsoft.com/en-us/dotnet/standard/base-types/trimming
        https://learn.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-7.0
        //originalString.Substring(0, originalString.Length - 1) para borrar datos al final de un string
         */

        //Funciones claves
        // String.Contains() string.Length Convert.ToDouble()

        public static string datoStr = "";
        public static float datoFloat = 0;
        public static double datoDouble = 0;

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            bool estado = true;
            while (estado)
            {
                Console.WriteLine("--Prototipo Proyecto 01: Concatenacion--");
                Console.WriteLine("1. Iniciar concatenacion.");
                Console.WriteLine("2. Salida");
                Console.WriteLine("Ingrese seleccion:");
                int.TryParse(Console.ReadLine(), out int opc);
                if(opc == 1) { Concatenar(); }
                else if(opc == 2) { estado = false; }
                else { Console.WriteLine("Seleccion invalida"); }
            }
        }

        static void Concatenar()
        {
            bool estado = true;
            while(estado)
            {
                Console.WriteLine($"Dato string: {datoStr} - Dato Float: {datoFloat} - Dato Double {datoDouble} - String Lenght: {datoStr.Length}");
                Console.WriteLine("1. (0-9) numero.\n2. Boton mas menos. 3.Reiniciar string. 4. Salida.\n:");
                int.TryParse(Console.ReadLine(), out int opc);
                estado = Opciones(opc);
            }
        }

        static bool Opciones(int opc) 
        {

            bool retVal = true;
            switch (opc)
            {
                case 1:
                    bool estado = true;
                    while (estado)
                    {
                        Console.WriteLine("Ingrese el valor (0-9) o signo (-) (,)");
                        string dato = Console.ReadLine();
                        if (dato != "-")
                        {
                            datoStr = datoStr + dato;
                            datoDouble = Convert.ToDouble(datoStr);
                        }
                        else if (dato == "-")
                        {
                            //NOTA: Signo - para numeros solo se puede agregar al principio del string.
                            //En caso que se agregue despues se asume que - fue presionado para la operacion y no para volver el numero negativo
                            if(datoStr.Length == 0)
                            {
                                datoStr = dato + datoStr;
                                Console.WriteLine($"==\n Dato Str: {datoStr}\n==");
                            }
                            else
                            {
                                Console.WriteLine("Cambio no posible ya que se agrego el valor");
                            }
                        }
                        else if(dato == ",")
                        {
                            //Signo , solo puede ser utilizado una vez. Si ya fue agregado no es posible ya que generara errores.
                            //Tampoco se puede concatenar con solo el signo -.Teoricamente eso daria cero.
                            //Previo a agregar, se debe validar que el string no contenga un , ya agregado
                            if (datoStr.Contains(","))
                            {
                                Console.WriteLine("Accion no posible");
                            }
                            else if (datoStr.Contains('-') && datoStr.Length == 1)
                            {
                                Console.WriteLine("Accion no posible");
                                //Excepcion para prevenir (-,)
                            }
                            else
                            {
                                datoStr = dato + ".";
                                datoDouble = Convert.ToDouble(datoStr);
                                Console.WriteLine($"==\n Dato Str: {datoStr}\n==");
                            }

                        }
                        Console.WriteLine("Hacer otro cambio? 1 Para salir");
                        int.TryParse(Console.ReadLine(), out opc);
                        if(opc == 1) { estado = false; }
                        else { Console.WriteLine("Redigiendo"); }
                    }
                    break;
                case 2:
                    if (datoStr.Contains('-'))
                    {
                        //Se asume que - esta al principio del string y lo elimina
                        datoStr = datoStr.Substring(1);
                        datoDouble = Convert.ToDouble(datoStr);
                    }
                    else
                    {
                        datoStr = "-" + datoStr; //Agrega el menos al principio del string
                        datoDouble = Convert.ToDouble(datoStr);
                    }
                    break;
                case 3:
                        datoStr = "";
                        datoFloat = 0;
                        datoDouble = 0;
                    break;
                case 4:
                    retVal = false;
                    break;
                default:
                    Console.WriteLine("Seleccion invalida");
                    break;
            }
            return retVal;
        }
    }
}
