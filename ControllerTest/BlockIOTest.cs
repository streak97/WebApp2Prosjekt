using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp2Prosjekt.BlackIO;

namespace BlockIOTesting
{
    [TestClass]
    public class BlockIOTest
    {

        [TestMethod]
        public void can_getNewAddress()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getNewAddress();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void can_getBalance()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getBalance();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void can_getMyAddresses()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getMyAddresses();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void can_getCurrentPrices()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getCurrentPrices();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void can_getTransactionsSent()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getTransactions("sent");

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void can_getTransactionsReceived()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.getTransactions("received");

            Assert.AreEqual("success", json.Status);
        }
    }
}
