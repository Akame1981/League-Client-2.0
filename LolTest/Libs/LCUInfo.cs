using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LolTest.Libs
{
    public static class LCUInfo
    {
        public static string currentSummoner = "/lol-summoner/v1/current-summoner";
        public static string currentRegion = "/riotclient/get_region_locale";
        private static HttpClient _httpClient;

        public static HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null) // create new instance only if still not created
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    httpClientHandler.ServerCertificateCustomValidationCallback = ((HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain cetChain, SslPolicyErrors policyErrors) => true);
                    _httpClient = new HttpClient(httpClientHandler)
                    {
                        DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("riot:" + Form1.pass)))
                }
                    };
                }
                return _httpClient;
            }
        }

    }



}
