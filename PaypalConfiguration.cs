using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStorebyNishu
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AVRVyTqc1Q4Yql86jU1qbWHCzDxmtq9XTvDKvuUbqagfa6B9SV9A9AdgL_k1QmHgE22zLp_htlel3Lkq";
            clientSecret = "ELThe4lcW38_LcfBiANV9DRLKazcNDa4_W5wXVnT2RU181BNGRJcidcsNBhyd825uJN_cruHfwbnBurU";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}