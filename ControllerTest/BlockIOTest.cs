using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp2Prosjekt.BlackIO;

namespace BlockIOTesting
{
    [TestClass]
    public class BlockIOTest
    {

        [TestMethod]
        public void Can_getNewAddress()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetNewAddress();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void Can_getBalance()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetBalance();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void Can_getMyAddresses()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetMyAddresses();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void Can_getCurrentPrices()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetCurrentPrices();

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void Can_getTransactionsSent()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetTransactions("sent");

            Assert.AreEqual("success", json.Status);
        }

        [TestMethod]
        public void Can_getTransactionsReceived()
        {
            string apiKey = "bb7c-fc4a-42a2-cf6e";
            BlockIO blockio = new BlockIO(apiKey);

            JSONAPI json = blockio.GetTransactions("received");

            Assert.AreEqual("success", json.Status);
        }
    }
}
