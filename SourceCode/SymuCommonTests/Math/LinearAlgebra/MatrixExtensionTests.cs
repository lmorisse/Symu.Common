#region Licence

// Description: SymuBiz - SymuCommonTests
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using MathNet.Numerics.LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symu.Common.Math.LinearAlgebra;

#endregion

namespace SymuCommonTests.Math.LinearAlgebra
{
    [TestClass]
    public class MatrixExtensionTests
    {
        /// <summary>
        ///     1 dim matrix filled with 0
        /// </summary>
        private readonly Matrix<float> _matrix10 = Matrix<float>.Build.Dense(1, 1);

        /// <summary>
        ///     1 dim matrix filled with 1
        /// </summary>
        private readonly Matrix<float> _matrix11 = Matrix<float>.Build.Dense(1, 1, 1F);

        /// <summary>
        ///     2 dim matrix filled with 0
        /// </summary>
        private readonly Matrix<float> _matrix20 = Matrix<float>.Build.Dense(2, 2);

        /// <summary>
        ///     2 dim matrix filled with 1
        /// </summary>
        private readonly Matrix<float> _matrix21 = Matrix<float>.Build.Dense(2, 2, 1F);

        /// <summary>
        ///     2 dim matrix identity
        /// </summary>
        private readonly Matrix<float> _matrix2Identity = Matrix<float>.Build.DenseIdentity(2);

        /// <summary>
        ///     2 dim matrix filled with 1
        /// </summary>
        private readonly Matrix<float> _matrix30 = Matrix<float>.Build.Dense(3, 3);

        [TestMethod]
        public void GrandSumTest()
        {
            Assert.AreEqual(0, _matrix10.GrandSum());
            Assert.AreEqual(1, _matrix11.GrandSum());
            Assert.AreEqual(0, _matrix20.GrandSum());
            Assert.AreEqual(4, _matrix21.GrandSum());
        }

        [TestMethod]
        public void NeighborhoodTest()
        {
            Assert.AreEqual(0, _matrix10.Neighborhood(0, 0).Sum());
            Assert.AreEqual(0, _matrix11.Neighborhood(0, 0).Sum());
            Assert.AreEqual(0, _matrix20.Neighborhood(0, 0).Sum());
            Assert.AreEqual(0, _matrix20.Neighborhood(0, 1).Sum());
            Assert.AreEqual(0, _matrix20.Neighborhood(1, 1).Sum());
            Assert.AreEqual(0, _matrix20.Neighborhood(1, 0).Sum());
            Assert.AreEqual(3, _matrix21.Neighborhood(0, 0).Sum());
            Assert.AreEqual(3, _matrix21.Neighborhood(1, 1).Sum());
            Assert.AreEqual(1, _matrix2Identity.Neighborhood(0, 0).Sum());
            Assert.AreEqual(1, _matrix2Identity.Neighborhood(1, 1).Sum());
            Assert.AreEqual(0, _matrix30.Neighborhood(2, 1).Sum());
        }

        [TestMethod]
        public void DegreeCentralityTest()
        {
            Assert.AreEqual(_matrix10, _matrix10.DegreeCentrality());
            Assert.AreEqual(_matrix10, _matrix11.DegreeCentrality());
            Assert.AreEqual(_matrix20, _matrix20.DegreeCentrality());
            Assert.AreEqual(Matrix<float>.Build.Dense(2, 2, 3F), _matrix21.DegreeCentrality());
            var result = Matrix<float>.Build.Dense(2, 2, 1F);
            result[0, 1] = 2;
            result[1, 0] = 2;
            Assert.AreEqual(result, _matrix2Identity.DegreeCentrality());
        }


        [TestMethod]
        public void MaximumTest()
        {
            Assert.AreEqual(1, _matrix2Identity.Maximum());
            _matrix2Identity[1, 1] = 2;
            Assert.AreEqual(2, _matrix2Identity.Maximum());
        }
    }
}