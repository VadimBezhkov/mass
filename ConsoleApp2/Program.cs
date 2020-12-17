﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //array output
        static void result(double[,] mass)
        {
            int arr1DimLen = mass.GetLength(0);
            int arr2DimLen = mass.GetLength(1);

            for (int y = 0; y < arr1DimLen; y++)
            {
                for (int x = 0; x < arr2DimLen; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(mass[y, x] + "\t");
                }
                Console.WriteLine();
            }
        }

        //sort an array in ascending order
        static void sortMax(double[,] mass)
        {

            int arr1DimLen = mass.GetLength(0);
            int arr2DimLen = mass.GetLength(1);

            for (int n = 0; n < mass.Length; n++)
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
                                double temp = mass[i, j];
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
                                    double temp = mass[i, j];
                                    mass[i, j] = mass[i + 1, 0];
                                    mass[i + 1, 0] = temp;
                                }
                            }
                        }
                    }
                }
            }
        }
        //sorting the array in descending order
        static void sortMin(double[,] mass)
        {
            int arr1DimLen = mass.GetLength(0);
            int arr2DimLen = mass.GetLength(1);

            for (int n = 0; n < mass.Length; n++)
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
                                double temp = mass[i, j];
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
                                    double temp = mass[i, j];
                                    mass[i, j] = mass[i + 1, 0];
                                    mass[i + 1, 0] = temp;
                                }
                            }
                        }
                    }
                }
            }
        }
        //input validation
        static double check1()
        {
            double number;
            while (true)
            {
                var input = Console.ReadLine();
                var condition = double.TryParse(input, out number);
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
        //input validation
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
            while (true)
            {
                // input of array dimension
                Console.ResetColor();
                Console.Write("enter the number of lines of the array:\t");
                int elements1 = check();

                Console.Write("enter the number of columns of the array:");
                int elements2 = check();
                Console.Clear();

                //variable declaration
                int positiveNumbers = 0;
                int negativeNumbers = 0;
                var exit = true;

                //and reading columns and rows and reading columns and rows
                double[,] mass = new double[elements1, elements2];
                int arr1DimLen = mass.GetLength(0);
                int arr2DimLen = mass.GetLength(1);

                //input of array elements
                for (int y = 0; y < arr1DimLen; y++)
                {
                    for (int x = 0; x < arr2DimLen; x++)
                    {
                        Console.WriteLine("X:" + y + "\tY:" + x);
                        mass[y, x] = check1();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("array output:\n");
                result(mass);

                while (exit)
                {
                    //array actions menu
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Find the number of positive numbers in a matrix - enter 1\n");
                    Console.WriteLine("Find the number of negative numbers in a matrix - enter 2\n");
                    Console.WriteLine("Sort matrix elements from left to right - enter 3\n");
                    Console.WriteLine("Sort matrix elements from right to left - enter 4\n");
                    Console.WriteLine("Inversion of matrix elements - enter 5\n");
                    Console.WriteLine("Introduce a new array - enter 6\n");
                    string chose = Console.ReadLine();

                    switch (chose)
                    {
                        //Find the number of positive numbers in a matrix
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            {

                                for (int y = 0; y < arr2DimLen; y++)
                                {
                                    for (int x = 0; x < arr1DimLen; x++)
                                    {
                                        if (mass[x, y] > 0)
                                        {
                                            positiveNumbers++;
                                        }
                                    }

                                }
                                Console.WriteLine($"Find the number of positive numbers in a matrix= {positiveNumbers}");

                                break;
                            }

                        //Find the number of negative numbers in a matrix
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            {

                                for (int y = 0; y < arr2DimLen; y++)
                                {
                                    for (int x = 0; x < arr1DimLen; x++)
                                    {
                                        if (mass[x, y] < 0)
                                        {
                                            negativeNumbers++;
                                        }
                                    }

                                }
                                Console.WriteLine($"Find the number of negative numbers in a matrix= {negativeNumbers}");

                                break;
                            }

                        //Sort matrix elements from left to right
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();

                            {
                                sortMax(mass);
                            }
                            result(mass);

                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();

                            {
                                sortMin(mass);
                            }
                            result(mass);

                            break;
                        //Inversion of matrix elements
                        case "5":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            {

                                for (int y = arr1DimLen - 1; y >= 0; y--)
                                {
                                    for (int x = arr2DimLen - 1; x >= 0; x--)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(mass[y, x] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                            }

                            break;
                        //Introduce a new array 
                        case "6":

                            {
                                exit = false;
                            }

                            break;
                    }
                }
                Console.Clear();
            }
        }
    }
}