#region Licence

// Description: SymuBiz - SymuCommon
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using System;
using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Symu.Common.Math.LinearAlgebra
{
    /// <summary>
    ///     Extension to the matrix class of MathNet package
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        ///     Technical method to calculate the grand sum of a matrix (the sum of all the elements)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static float GrandSum(this Matrix<float> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            return matrix.RowSums().Sum();
        }

        /// <summary>
        ///     Create the DegreeCentrality matrix of a matrix.
        ///     The degree centrality count the number of neighbors that a node has
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix<float> DegreeCentrality(this Matrix<float> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var result = Matrix<float>.Build.Dense(matrix.RowCount, matrix.ColumnCount);
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    result[i, j] = matrix.Neighborhood(i, j).Sum();
                }
            }

            return result;
        }

        /// <summary>
        ///     Return all the nodes around a node (i, j) in a vector format
        ///     in a clockwise rotation
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static Vector<float> Neighborhood(this Matrix<float> matrix, int i, int j)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (i == 0)
            {
                if (matrix.ColumnCount == 1)
                {
                    return Vector<float>.Build.Dense(0);
                }

                if (j == 0)
                {
                    var result = Vector<float>.Build.Dense(3);
                    result[0] = matrix[0, 1];
                    result[1] = matrix[1, 1];
                    result[2] = matrix[1, 0];
                    return result;
                }

                if (j == matrix.ColumnCount - 1)
                {
                    var result = Vector<float>.Build.Dense(3);
                    result[0] = matrix[1, j];
                    result[1] = matrix[1, j - 1];
                    result[2] = matrix[0, j - 1];
                    return result;
                }
                else
                {
                    var result = Vector<float>.Build.Dense(5);
                    result[0] = matrix[0, j + 1];
                    result[1] = matrix[1, j + 1];
                    result[2] = matrix[1, j];
                    result[3] = matrix[1, j - 1];
                    result[4] = matrix[0, j - 1];
                    return result;
                }
            }

            if (matrix.RowCount == 1)
            {
                return Vector<float>.Build.Dense(0);
            }

            if (j == 0)
            {
                if (i == matrix.RowCount - 1)
                {
                    var result = Vector<float>.Build.Dense(3);
                    result[0] = matrix[i - 1, 0];
                    result[1] = matrix[i - 1, 1];
                    result[2] = matrix[i, 1];
                    return result;
                }
                else
                {
                    var result = Vector<float>.Build.Dense(5);
                    result[0] = matrix[i - 1, 0];
                    result[1] = matrix[i - 1, 1];
                    result[2] = matrix[i, 1];
                    result[3] = matrix[i + 1, 1];
                    result[4] = matrix[i + 1, 0];
                    return result;
                }
            }

            if (j == matrix.ColumnCount - 1)
            {
                if (i == matrix.RowCount - 1)
                {
                    var result = Vector<float>.Build.Dense(3);
                    result[0] = matrix[i - 1, j];
                    result[1] = matrix[i, j - 1];
                    result[2] = matrix[i - 1, j - 1];
                    return result;
                }
                else
                {
                    var result = Vector<float>.Build.Dense(5);
                    result[0] = matrix[i - 1, j];
                    result[1] = matrix[i + 1, j];
                    result[2] = matrix[i + 1, j - 1];
                    result[3] = matrix[i, j - 1];
                    result[4] = matrix[i - 1, j - 1];
                    return result;
                }
            }

            if (i == matrix.RowCount - 1)
            {
                var result = Vector<float>.Build.Dense(5);
                result[0] = matrix[i - 1, j];
                result[1] = matrix[i - 1, j + 1];
                result[2] = matrix[i, j + 1];
                result[3] = matrix[i, j - 1];
                result[4] = matrix[i - 1, j - 1];
                return result;
            }
            else
            {
                var result = Vector<float>.Build.Dense(8);
                result[0] = matrix[i - 1, j];
                result[1] = matrix[i - 1, j + 1];
                result[2] = matrix[i, j + 1];
                result[3] = matrix[i + 1, j + 1];
                result[4] = matrix[i + 1, j];
                result[5] = matrix[i + 1, j - 1];
                result[6] = matrix[i, j - 1];
                result[7] = matrix[i - 1, j - 1];
                return result;
            }
        }

        public static float Maximum(this Matrix<float> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            var result = matrix[0, 0];
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    result = System.Math.Max(result, matrix[i, j]);
                }
            }

            return result;
        }
    }
}