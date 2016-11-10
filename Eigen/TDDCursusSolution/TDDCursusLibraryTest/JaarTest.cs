using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;


namespace TDDCursusLibraryTest
{
    [TestClass]
    public class JaarTest
    {
        [TestMethod]
        public void EenJaarDeelbaarDoor400IsEenSchrikkeljaar()
        {
            var jaar=new Jaar(2000);
            Assert.AreEqual(true, jaar.IsSchrikkeljaar);
        }
    }
}
