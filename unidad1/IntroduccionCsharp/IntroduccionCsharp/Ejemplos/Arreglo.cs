﻿using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace IntroduccionCsharp.Ejemplos
{
    public class Arreglo
    {
        public int ver { get; set;}
        public Arreglo (int ver)
        {
            this.ver = ver;
        }
        public void PrintArray()
        {
            string[] nombres = { "Juan", "Maria", "Ruperto", "Petronila", "Ramon" };
            foreach (var nombre in nombres)
            {
                Console.WriteLine("Hola " + nombre);
            }
        }

       
        public void PrintArrayLimit()
        {
            string[] nombres = { "Juan", "Maria", "Ruperto", "Petronila", "Ramon" };
            for (int i = 0; i < ver; i++)
            {
                Console.WriteLine("Hola " + nombres[i]);
            }
            //int x = 0;
            //foreach (var nombre in nombres)
            //{
            //    if (x < ver)
            //    {
            //        Console.WriteLine("Hola " + nombre);  
            //    }
            //    x++;
            //}
        }
    }
}
