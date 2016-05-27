using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddHerhaling;
using Moq;

namespace TDDHerhalingTests
{
    [TestClass]
    public class WinstserviceTest
    {
        private IKostDAO kostDAO;
        private IOpbrengstDAO opbrengstDAO;
        private Mock<IKostDAO> mockKostDAO;
        private Mock<IOpbrengstDAO> mockOpbrengstDAO; 
        private Winstservice winstservice ;
        [TestInitialize]
        public void Initialize()
        {
            mockKostDAO = new Mock<IKostDAO>();
            kostDAO=mockKostDAO.Object;
            mockOpbrengstDAO = new Mock<IOpbrengstDAO>();
            opbrengstDAO =mockOpbrengstDAO.Object ;
            winstservice = new Winstservice(kostDAO,opbrengstDAO);
        }

        [TestMethod]
        public void DeWinstZijnDeKostenAfgetrokkenVanDeOpbrengsten()
        {
            mockKostDAO.Setup(eenKost => eenKost.TotaleKost()).Returns(10);
            mockOpbrengstDAO.Setup(eenOpbrengst => eenOpbrengst.TotaleOpbrengst()).Returns(30);
            Assert.AreEqual(20,winstservice.Winst);
        }
    }
}
