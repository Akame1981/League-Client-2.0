using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Http.Headers;

namespace LolTest.Libs
{
    public class AutoAccept
    {
        public static async void Accept(string pass, string port)
        {

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (requestMessage, certificate, chain, policyErrors) => true;

            // In production code, don't destroy the HttpClient through using, but better use IHttpClientFactory factory or at least reuse an existing HttpClient instance
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
            // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://127.0.0.1:"+ port +"/lol-matchmaking/v1/ready-check/accept"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic " + pass);

                    request.Content = new StringContent("");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);


                }
            }

            



            //lol-lobby/v2/lobby
        }


    }
}
