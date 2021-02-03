#region Licence

// Description: SymuBiz - SymuCommonTests
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symu.Common.Core.Math.ProbabilityDistributions;

#endregion

namespace SymuCommonTests.Math.ProbabilityDistributions
{
    [TestClass]
    public class LogNormalTests
    {
        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual(0, LogNormal.Sample(0, 0));
            Assert.AreEqual(1, LogNormal.Sample(1, 0));
        }
    }
}