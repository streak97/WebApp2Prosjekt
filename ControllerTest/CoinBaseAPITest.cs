using System.Net.Http;
using System.Threading.Tasks;
using Coinbase;
using Flurl.Http;
using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinBaseAPITesting
{
    [TestClass]
    public class CoinBaseAPITest
    {
        private HttpTest server;

        [TestInitialize]
        public void BeforeEachTest()
        {
            server = new HttpTest();
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            server.Dispose();
        }

        [TestMethod]
        public async Task Can_create_authorization_url()
        {
            var opts = new AuthorizeOptions
            {
                ClientId = "YOUR_CLIENT_ID",
                RedirectUri = "YOUR_REDIRECT_URL",
                State = "SECURE_RANDOM",
                Scope = "wallet:accounts:read"
            };
            var authUrl = OAuthHelper.GetAuthorizeUrl(opts);

            var url =
                "https://www.coinbase.com/oauth/authorize?response_type=code&client_id=YOUR_CLIENT_ID&redirect_uri=YOUR_REDIRECT_URL&state=SECURE_RANDOM&scope=wallet%3Aaccounts%3Aread";


            var response = await authUrl.GetAsync();

            server.ShouldHaveCalled(url);

        }

        [TestMethod]
        public async Task Can_revoke_token()
        {
            server.RespondWith("");

            var x = await OAuthHelper.RevokeTokenAsync("fff", "vvv");

            server.ShouldHaveCalled("https://api.coinbase.com/oauth/revoke")
                .WithVerb(HttpMethod.Post)
                .WithRequestBody("token=fff&access_token=vvv");
        }
    }
}