using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class RotateMatrix
    {
        //public static void Main(string[] args)
        //{
        //    int[,] matrix =
        //    {
        //        {1,2,3 },
        //        {4,5,6 },
        //        {7,8,9 }
        //    };

        //    RotateMatrixFunc(matrix, 4);
        //}
        static void RotateMatrixFunc(int[,] matrix,int rotations,Boolean clockwise=true)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] rotatedMatrix = new int[cols, rows];
            Console.WriteLine($"Original Matrix Rotating {(clockwise?"Clockwise":"Anti ClockWise")}");
            PrintRotates(matrix);
            for(int i = 0; i < rotations; i++)
            {
                for(int row = 0; row < rows; row++)
                {
                    for(int col = 0;col < cols; col++)
                    {
                        int value = (rows - 1 - row);
                        //Console.WriteLine($"{col} {row} origVal:{matrix[col,row]} val:{value} changeval: {matrix[col,value]}  ");
                        //rotatedMatrix[col, rows - 1 - row] = matrix[row, col];
                        rotatedMatrix[col, rows - 1 - row] = clockwise ? matrix[row, col] : matrix[col, row];
                    }
                }
                matrix =(int[,])rotatedMatrix.Clone();
                Console.WriteLine($"Rotation: {i}");
                PrintRotates(rotatedMatrix);
            }
           
        }

        static void PrintRotates(int[,] matrix)

        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + "|");
                }
                Console.WriteLine();
            }
        }
    }
}
