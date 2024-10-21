using System;
using System.Collections.Generic;

public class DiccionarioInglesEspanol
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>();

    
    static List<string> palabrasIngles = new List<string>();
    static List<string> palabrasEspanol = new List<string>();

    public static void Main()
    {
        
        crearDiccionario();
        traducir();
    }

    
    public static void crearDiccionario()
    {
        Console.WriteLine("Introduce 5 pares de palabras (Inglés - Español):");

        
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Palabra en inglés: ");
            string palabraIngles = Console.ReadLine().ToLower();
            palabrasIngles.Add(palabraIngles);  

            Console.Write("Palabra en español: ");
            string palabraEspanol = Console.ReadLine().ToLower();
            palabrasEspanol.Add(palabraEspanol);  
        }

        
        for (int i = 0; i < palabrasIngles.Count; i++)
        {
            diccionario[palabrasIngles[i]] = palabrasEspanol[i];
        }

        Console.WriteLine("\nDiccionario creado con éxito.\n");
    }

    
    public static void traducir()
    {
        string palabra;
        do
        {
            Console.Write("Introduce una palabra en inglés para traducir (o 'salir' para terminar): ");
            palabra = Console.ReadLine().ToLower();

            if (palabra != "salir")
            {
                if (diccionario.ContainsKey(palabra))
                {
                    Console.WriteLine($"La traducción de '{palabra}' es: {diccionario[palabra]}\n");
                }
                else
                {
                    Console.WriteLine($"La palabra '{palabra}' no se encuentra en el diccionario.\n");
                }
            }

        } while (palabra != "salir" && palabra != "Salir");

        Console.WriteLine("Programa finalizado.");
    }
}

