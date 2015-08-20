namespace DefiningClasses
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Matrix<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        T[,] arr;

        public Matrix(int row, int col)
        {
            arr = new T[row, col];
        }

        public T this[int row, int col]
        {
            get
            {
                CheckRowCol(row, col);
                return this.arr[row, col];
            }
            set
            {
                CheckRowCol(row, col);
                this.arr[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> M1, Matrix<T> M2)
        {
            Matrix<T>.CheckIfMatricesAreSameSize(M1, M2);
            T[,] newArr = new T[M1.arr.GetLength(0), M1.arr.GetLength(1)];
            for (int row = 0; row < M1.arr.GetLength(0); row++)
            {
                for (int col = 0; col < M1.arr.GetLength(1); col++)
                {
                    newArr[row, col] = (dynamic)M1.arr[row, col] + (dynamic)M2.arr[row, col];
                }
            }
            return new Matrix<T>(M1.arr.GetLength(0), M1.arr.GetLength(1)) { arr = newArr };
        }

        public static Matrix<T> operator -(Matrix<T> M1, Matrix<T> M2)
        {
            Matrix<T>.CheckIfMatricesAreSameSize(M1, M2);
            T[,] newArr = new T[M1.arr.GetLength(0), M1.arr.GetLength(1)];
            for (int row = 0; row < M1.arr.GetLength(0); row++)
            {
                for (int col = 0; col < M1.arr.GetLength(1); col++)
                {
                    newArr[row, col] = (dynamic)M1.arr[row, col] - (dynamic)M2.arr[row, col];
                }
            }
            return new Matrix<T>(M1.arr.GetLength(0), M1.arr.GetLength(1)) { arr = newArr };
        }

        public static Matrix<T> operator *(Matrix<T> M1, Matrix<T> M2)
        {
            Matrix<T>.CheckIfMatricesAreMultipliable(M1, M2);
            T[,] newArr = new T[M1.arr.GetLength(0), M2.arr.GetLength(1)];
            for (int row = 0; row < M1.arr.GetLength(0); row++)
            {
                for (int col = 0; col < M2.arr.GetLength(1); col++)
                {
                    T result = default(T);
                    for (int counter = 0; counter < M1.arr.GetLength(0); counter++)
                    {
                        result += (dynamic)M1.arr[row, counter] * (dynamic)M2.arr[counter, col];
                    }
                    newArr[row, col] = result;
                }
            }
            return new Matrix<T>(M1.arr.GetLength(0), M2.arr.GetLength(1)) { arr = newArr };
        }

        public static Matrix<T> operator *(int number, Matrix<T> M1)
        {
            T[,] newArr = new T[M1.arr.GetLength(0), M1.arr.GetLength(1)];
            for (int row = 0; row < M1.arr.GetLength(0); row++)
            {
                for (int col = 0; col < M1.arr.GetLength(1); col++)
                {
                    newArr[row, col] = (dynamic)M1.arr[row, col] * number;
                }
            }
            return new Matrix<T>(M1.arr.GetLength(0), M1.arr.GetLength(1)) { arr = newArr };
        }

        public static bool IsNonZero(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.arr.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.arr.GetLength(1); col++)
                {
                    if ((dynamic)matrix.arr[row,col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void CheckIfMatricesAreMultipliable(Matrix<T> first, Matrix<T> second)
        {
            if (first.arr.GetLength(0) != second.arr.GetLength(1))
            {
                throw new ArgumentException("Matrices are not multipliable!");
            }
        }

        private static void CheckIfMatricesAreSameSize(Matrix<T> first, Matrix<T> second)
        {
            if (first.arr.GetLength(0) != second.arr.GetLength(0) || first.arr.GetLength(1) != second.arr.GetLength(1))
            {
                throw new ArgumentException("Matrices are not same size!");
            }
        }

        private void CheckRowCol(int row, int col)
        {
            if (row < 0 || row >= this.arr.GetLength(0) || col < 0 || col >= this.arr.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Wrong row/col!");
            }
        }
    }
}
