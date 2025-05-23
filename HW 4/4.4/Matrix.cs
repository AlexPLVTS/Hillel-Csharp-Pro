using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4._4
{
    internal class Matrix
    {
        public int[,] matrix;
        public int cols;
        public int rows;
        public Matrix(int cols, int rows, int[,] matrix)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Rows and columns must be positive integers.");

            if (matrix.GetLength(0) != rows || matrix.GetLength(1) != cols)
                throw new ArgumentException("Matrix dimensions do not match specified rows and columns.");
            this.rows = rows;
            this.cols = cols;
            this.matrix = matrix;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            int[,] result = new int[a.cols, a.rows];
            if (a.cols != b.cols || a.rows != b.rows)
            {
                throw new ArgumentException("Cannot make operation on matrices with different dimensions");
            }
            for (int i = 0; i < a.cols; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    result[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return new Matrix(a.cols, a.rows, result);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    sb.Append("[" + matrix[i, j] + "]" + "\t");
                }
                sb.AppendLine("\n");
            }
            return sb.ToString();
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.cols != b.cols || a.rows != b.rows)
            {
                throw new ArgumentException("Cannot make operation on matrices with different dimensions");
            }
            int[,] result = new int[a.cols, a.rows];
            for (int i = 0; i < a.cols; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    result[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return new Matrix(a.cols, a.rows, result);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.cols != b.cols || a.rows != b.rows)
            {
                throw new ArgumentException("Cannot make operation on matrices with different dimensions");
            }
            int[,] result = new int[a.cols, a.rows];
            for (int i = 0; i < a.cols; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    result[i, j] = a.matrix[i, j] * b.matrix[i, j];
                }
            }
            return new Matrix(a.cols, a.rows, result);
        }
        public static Matrix operator *(Matrix a, int multy)
        {
            int[,] result = new int[a.cols, a.rows];
            for (int i = 0; i < a.cols; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    result[i, j] = a.matrix[i, j] * multy;
                }
            }
            return new Matrix(a.cols, a.rows, result);
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.cols != b.cols || a.rows != b.rows)
            {
                throw new ArgumentException("Cannot make operation on matrices with different dimensions");
            }
            for (int i = 0; i < a.cols; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    if (a.matrix[i, j] != b.matrix[i, j])
                        return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
    }
}
