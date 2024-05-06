using System;
using System.Threading;

namespace Multithread
{
    internal class MatrixCalculations
    {
        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            
            if (colsA != rowsB)
            {
                throw new ArgumentException("Number of columns in the first matrix must equal the number of rows in the second matrix.");
            }

            int[,] resultMatrix = new int[rowsA, colsB];

          
            Thread t1 = new Thread(() => { resultMatrix[0, 0] = Multiply(matrixA, matrixB, 0, 0); });
            Thread t2 = new Thread(() => { resultMatrix[0, 1] = Multiply(matrixA, matrixB, 0, 1); });
            Thread t3 = new Thread(() => { resultMatrix[1, 0] = Multiply(matrixA, matrixB, 1, 0); });
            Thread t4 = new Thread(() => { resultMatrix[1, 1] = Multiply(matrixA, matrixB, 1, 1); });

            
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

           
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            return resultMatrix;
        }

        private static int Multiply(int[,] matrixA, int[,] matrixB, int row, int col)
        {
            int sum = 0;
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                sum += matrixA[row, k] * matrixB[k, col];
            }
            return sum;
        }
    }
}
