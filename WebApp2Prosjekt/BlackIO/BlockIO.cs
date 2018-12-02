using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace WebApp2Prosjekt.BlackIO
{

    public class BlockIO
    {
        private string ApiKey { get; set; }
        private readonly string Url = "https://block.io/api/v2/";

        public BlockIO(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        private JSONAPI Wallet_API(string method, NameValueCollection parameters)
        {
            WebClient Client = new WebClient();
            Uri url = new Uri(Url + method + "/");
            JSONAPI json = new JSONAPI();


            string JSONString = string.Empty;
            parameters.Add("api_key", this.ApiKey);

            try
            {
                JSONString = Client.DownloadString(url + "?" + parameters.ToString());
            }
            catch (WebException ex)
            {
                JSONString = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            }

            json = JsonConvert.DeserializeObject<JSONAPI>(JSONString);
            if (json.Status == "success")
            {
                if (json.Data.ContainsKey("user_id"))
                {
                    json.Data["user_id"] = Convert.ToInt32(json.Data["user_id"]);
                }
            }
            else
            {
                throw new Exception("Block.io API Error: " + json.Data["error_message"]);
            }

            return json;
        }

        public JSONAPI GetNewAddress()
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);
            return Wallet_API("get_new_address", Params);
        }

        public JSONAPI GetBalance()
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);
            return Wallet_API("get_balance", Params);
        }

        public JSONAPI GetMyAddresses()
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);
            return Wallet_API("get_my_addresses", Params);
        }

        public JSONAPI GetCurrentPrices()
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);
            return Wallet_API("get_current_prices", Params);
        }

        public JSONAPI GetTransactions(string type)
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);
            Params.Add("type", type);
            return Wallet_API("get_transactions", Params);
        }

        public JSONAPI Withdraw(string amounts, string addresses, string pin)
        {
            NameValueCollection Params = System.Web.HttpUtility.ParseQueryString(string.Empty);

            Params.Add("amounts", amounts);
            Params.Add("to_addresses", addresses);
            Params.Add("pin", pin);

            return Wallet_API("withdraw", Params);
        }
    }
}
