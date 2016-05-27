using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class JaarTest
    {
        [TestMethod]
        public void EenJaarIsDeelbaarDoor400IsEenSchrikkeljaar()
        {
            var jaar = new Jaar(2000);
            Assert.AreEqual(true, jaar.IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarIsDeelbaarDoor100IsGeenSchrikkeljaar()
        {
            var jaar = new Jaar(1900);
            Assert.AreEqual(false, jaar.IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarIsDeelbaarDoor4IsEenSchrikkeljaar()
        {
            var jaar = new Jaar(2012);
            Assert.AreEqual(true, jaar.IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarIsDeelbaarDoor4IsGeenSchrikkeljaar()
        {
            var jaar = new Jaar(2015);
            Assert.AreEqual(false, jaar.IsSchrikkeljaar);
        }
    }
}
