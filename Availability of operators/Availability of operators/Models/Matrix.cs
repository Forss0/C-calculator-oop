using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availability_of_operators.Work
{
    namespace Models
    {
        public class Matrix
        {
            private int[,] arr;

            public int Rows { get; }
            public int Cols { get; }

            public Matrix(int rows, int cols)
            {
                Rows = rows;
                Cols = cols;
                arr = new int[rows, cols];
            }

            // Індексатор
            public int this[int i, int j]
            {
                get { return arr[i, j]; }
                set { arr[i, j] = value; }
            }

            // + додавання матриць
            public static Matrix operator +(Matrix a, Matrix b)
            {
                Matrix result = new Matrix(a.Rows, a.Cols);

                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        result[i, j] = a[i, j] + b[i, j];

                return result;
            }

            // - віднімання матриць
            public static Matrix operator -(Matrix a, Matrix b)
            {
                Matrix result = new Matrix(a.Rows, a.Cols);

                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        result[i, j] = a[i, j] - b[i, j];

                return result;
            }

            // * множення матриць
            public static Matrix operator *(Matrix a, Matrix b)
            {
                Matrix result = new Matrix(a.Rows, b.Cols);

                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < b.Cols; j++)
                    {
                        result[i, j] = 0;
                        for (int k = 0; k < a.Cols; k++)
                        {
                            result[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }

                return result;
            }

            // * множення на число
            public static Matrix operator *(Matrix m, int num)
            {
                Matrix result = new Matrix(m.Rows, m.Cols);

                for (int i = 0; i < m.Rows; i++)
                    for (int j = 0; j < m.Cols; j++)
                        result[i, j] = m[i, j] * num;

                return result;
            }

            // == та !=
            public static bool operator ==(Matrix a, Matrix b)
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        if (a[i, j] != b[i, j]) return false;

                return true;
            }

            public static bool operator !=(Matrix a, Matrix b)
            {
                return !(a == b);
            }
        }
    }
}
