using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void sortMax(decimal[,]mass)
        {
            int arr1DimLen = mass.GetLength(0);
            int arr2DimLen = mass.GetLength(1);

            for (int k = 0; k < mass.Length; k++)
            {
                bool isLastRow = false;
                for (int i = 0; i < arr1DimLen; i++)
                {
                    if (i == arr1DimLen - 1)
                        isLastRow = true;
                    for (int j = 0; j < arr2DimLen; j++)
                    {
                        if (j < arr2DimLen - 1)
                        {
                            if (mass[i, j] > mass[i, j + 1])
                            {
                                decimal temp = mass[i, j];
                                mass[i, j] = mass[i, j + 1];
                                mass[i, j + 1] = temp;
                            }
                        }
                        else
                        {
                            if (!isLastRow)
                            {
                                if (mass[i, j] > mass[i + 1, 0])
                                {
                                    decimal temp = mass[i, j];
                                    mass[i, j] = mass[i + 1, 0];
                                    mass[i + 1, 0] = temp;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void sortMin(decimal[,] mass)
        {
            int arr1DimLen = mass.GetLength(0);
            int arr2DimLen = mass.GetLength(1);

            for (int k = 0; k < mass.Length; k++)
            {
                bool isLastRow = false;
                for (int i = 0; i < arr1DimLen; i++)
                {
                    if (i == arr1DimLen - 1)
                        isLastRow = true;
                    for (int j = 0; j < arr2DimLen; j++)
                    {
                        if (j < arr2DimLen - 1)
                        {
                            if (mass[i, j] < mass[i, j + 1])
                            {
                                decimal temp = mass[i, j];
                                mass[i, j] = mass[i, j + 1];
                                mass[i, j + 1] = temp;
                            }
                        }
                        else
                        {
                            if (!isLastRow)
                            {
                                if (mass[i, j] < mass[i + 1, 0])
                                {
                                    decimal temp = mass[i, j];
                                    mass[i, j] = mass[i + 1, 0];
                                    mass[i + 1, 0] = temp;
                                }
                            }
                        }
                    }
                }
            }
        }
        static decimal check1()
        {
            decimal number;
            while (true)
            {
                var input = Console.ReadLine();
                var condition = decimal.TryParse(input, out number);
                if (condition)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Error enter number");
                }
            }
        }
        static int check()
        {
            int number;
            while (true)
            {
                var input = Console.ReadLine();
                var condition = int.TryParse(input, out number);
                if (condition)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Error enter number");
                }
            }
        }
        static void Main(string[] args)
        {

            Console.Write("enter the number of lines of the array:\t");
            int elements1 = check();
            Console.Write("enter the number of columns of the array:");
            int elements2 = check();
            Console.Clear();

            int value = 0;
            int value1 = 0;
            var exit = true;

            decimal[,] mass = new decimal[elements1, elements2];
            int height = mass.GetLength(0);
            int width = mass.GetLength(1);

            for (int y = 0; y < height; y++)
            {

                for (int x = 0; x < width; x++)
                {
                    Console.WriteLine("X:"+ y + "\tY:" + x);
                    mass[y, x] = check1();
                }
            }

            Console.WriteLine();
            Console.WriteLine("array output:\n");

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(mass[y, x] + "\t");
                }
                Console.WriteLine();
            }

            while (exit)
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Find the number of positive numbers in a matrix - enter 1\n");
                Console.WriteLine("Find the number of negative numbers in a matrix - enter 2\n");
                Console.WriteLine("Sort matrix elements from left to right - enter 3\n");
                Console.WriteLine("Sort matrix elements from right to left - enter 4\n");
                Console.WriteLine("Inversion of matrix elements - enter 5");
                Console.WriteLine("Exit - enter 6");
                string chose = Console.ReadLine();

                switch (chose)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        {
                            for (int y = 0; y < width; y++)
                            {
                                for (int x = 0; x < height; x++)
                                {
                                    if (mass[y, x] > 0)
                                    {
                                        value++;
                                    }
                                }
                            }
                            Console.WriteLine($"Find the number of positive numbers in a matrix= {value}");

                            break;
                        }
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        {
                            for (int y = 0; y < width; y++)
                            {
                                for (int x = 0; x < height; x++)
                                {
                                    if (mass[x, y] < 0)
                                    {
                                        value1++;
                                    }
                                }
                            }
                            Console.WriteLine($"Find the number of negative numbers in a matrix= {value1}");

                            break;
                        }
                    case "3":
                        {
                            sortMax(mass);
                        }
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(mass[y, x] + "\t");
                            }
                        }

                        break;
                    case "4":
                        {
                            sortMin(mass);
                        }
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(mass[y, x] + "\t");
                            }
                        }

                        break;
                    case "6":
                        {
                            Console.WriteLine("Exit");
                            exit = false;
                        }
                        break;
                }
                Console.WriteLine("press any button to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}