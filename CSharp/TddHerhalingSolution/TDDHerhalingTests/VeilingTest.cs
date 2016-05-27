using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddHerhaling;
namespace TDDHerhalingTests
{
    [TestClass]
    public class VeilingTest
    {
        private Veiling veiling;
        [TestInitialize]
        public void Initialize()
        {
             veiling = new Veiling();
        }
        [TestMethod]
        public void NogGeenBodGekregenIsHoogsteBodNul()
        {

            Assert.AreEqual(0, veiling.getHoogsteBod);
        }
        [TestMethod]
        public void HetEersteBodIsHetHoogsteBodDezeBieding()
        {
            veiling.DoeBod(30m);
            Assert.AreEqual(30, veiling.getHoogsteBod);
        }
        [TestMethod]
        public void BijMeerdereBiedingenIsHetHoogsteBodHetHoogsteVanAlleBiedingen()
        {
            veiling.DoeBod(150m);
            veiling.DoeBod(300m);
            veiling.DoeBod(250m);
            Assert.AreEqual(300m, veiling.getHoogsteBod);
            
        }
    }
}
