using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddHerhaling;

namespace TDDHerhalingTests
{
    [TestClass]
    public class WoordTest
    {
      
        [TestMethod]
        public void HetWoordIsPalindroomIsCorrect()
        {
            var woord=new Woord("lepel");
            Assert.AreEqual(true, woord.IsPalindroom());
        }
        [TestMethod]
       
        public void HetWoordIsPalindroomISIncorrect()
        {
            var woord = new Woord("banaan");
            Assert.AreEqual(false, woord.IsPalindroom());
        }
        [TestMethod]
       
        public void EenLegeStringIsPalindroomIsCorrect()
        {
            var woord = new Woord("");
            Assert.AreEqual(true, woord.IsPalindroom());
        }
    }
}
