using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddHerhaling;

namespace TDDHerhalingTests
{
    [TestClass]
    public class ISBNTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetISBNnummerBestaatUit12Cijfers()
        {
            new ISBN(978902743964L);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetISBNnummerBestaatUit14Cijfers()
        {
            new ISBN(97890274396423L);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetISBNnummerMagNietNegatiefZijn()
        {
            new ISBN(-9789027439642L);
        }
        [TestMethod,ExpectedException(typeof(ArgumentException))]
        public void Het13deCijferVanISBNnummerMoet2zijnIsIncorrect()
        {
            new ISBN(7789027439642L);
        }
        [TestMethod]
        public void Het13deCijferVanISBNnummerMoet2zijnIsCorrect()
        {
            new ISBN(9789027439642L);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Het13deCijferVanISBNnummerMoet0zijnIsIncorrect()
        {
            new ISBN(7789027439642L);
        }
        [TestMethod]
        public void Het13deCijferVanISBNnummerMoet0zijnIsCorrect()
        {
            new ISBN(7789227439640L);
        }
        [TestMethod]
      public void ToStringMoetEenGeldigISBNnummerTerugGeven()
      {
          string nummer = "9789027439642";
          Assert.AreEqual(nummer, new ISBN(long.Parse(nummer)).ToString());
      }

    }
}   
