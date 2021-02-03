#region Licence

// Description: SymuBiz - SymuCommonTests
// Website: https://symu.org
// Copyright: (c) 2020 laurent morisseau
// License : the program is distributed under the terms of the GNU General Public License

#endregion

#region using directives

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symu.Common.Core.Classes;

#endregion

namespace SymuCommonTests.Classes
{
    [TestClass]
    public class ModelEntityTests
    {
        private readonly ModelEntity _entity = new ModelEntity();

        /// <summary>
        ///     Rate 1 - Model Off
        /// </summary>
        [TestMethod]
        public void IsAgentOnTest()
        {
            _entity.On = false;
            _entity.RateOfAgentsOn = 1F;
            Assert.IsFalse(_entity.IsAgentOn());
        }

        /// <summary>
        ///     Rate 1 - Model ON
        /// </summary>
        [TestMethod]
        public void IsAgentOnTest1()
        {
            _entity.RateOfAgentsOn = 1F;
            _entity.On = true;
            Assert.IsTrue(_entity.IsAgentOn());
        }

        /// <summary>
        ///     Rate 0 - model on
        /// </summary>
        [TestMethod]
        public void IsAgentOnTest2()
        {
            _entity.On = true;
            _entity.RateOfAgentsOn = 0F;
            Assert.IsFalse(_entity.IsAgentOn());
        }
    }
}