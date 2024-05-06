using System;

namespace Multithread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NOTE: Matrix multiplication is only valid if \n" +
                  "the number of columns of the first matrix are equal to the number of rows of the second matrix");

            int[,] matrixA = null;
            int[,] matrixB = null;

            while (true)
            {
                Console.WriteLine("\nChoose the operation:");
                Console.WriteLine("1. Input new matrices");
                Console.WriteLine("2. Multiplication");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Input Matrix A:");
                        matrixA = MatrixInput.InputMatrix("A");
                        Console.WriteLine("Input Matrix B:");
                        matrixB = MatrixInput.InputMatrix("B");
                        break;
                    case 2:
                        if (matrixA == null || matrixB == null)
                        {
                            Console.WriteLine("You forgot to enter matrices");
                            break;
                        }
                        Console.WriteLine("\nResult Matrix (Multiplication):");
                        MatrixPrint.PrintMatrix(MatrixCalculations.MultiplyMatrices(matrixA, matrixB));
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}