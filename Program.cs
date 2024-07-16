using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace OclcApiTest
{
    internal class Program
    {
        private static OclcTokenResponse GetOclcToken()
        {
            OclcTokenResponse oclcTokenResponse = null;

            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
                {
                    var baseAddress = new Uri(Config.OclcTokenUrl);

                    var clientId = HttpUtility.UrlEncode(Config.OclcClientId);
                    var clientSecret = HttpUtility.UrlEncode(Config.OclcClientSecret);
                    var authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" },
                        { "scope", Config.OclcScope }
                    });

                    HttpResponseMessage response = client.PostAsync("", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var formatters = new List<MediaTypeFormatter>()
                        {
                            new JsonMediaTypeFormatter(),
                            new XmlMediaTypeFormatter()
                        };

                        oclcTokenResponse = response.Content.ReadAsAsync<OclcTokenResponse>(formatters).Result;
                    }
                    else
                    {
                        var errorMessage = response.Content.ReadAsStringAsync().Result;

                        Console.WriteLine($"GetOclcToken Failed \"{errorMessage}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetOclcToken failed: {ex.Message}");
            }

            return oclcTokenResponse;
        }

        private static bool ProcessTheResponse(HttpResponseMessage response)
        {
            string oclcSubmissionNotes = "";

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(content);

                return true;
            }
            else
            {
                var formatters = new List<MediaTypeFormatter>()
                {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var oclcBadRequestResponse = response.Content.ReadAsAsync<OclcBadRequestResponse>(formatters).Result;

                    oclcSubmissionNotes = string.Join(" ", oclcBadRequestResponse.errors);
                }
                else if (response.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    var oclcNotAcceptableResponse = response.Content.ReadAsAsync<OclcNotAcceptableResponse>(formatters).Result;

                    oclcSubmissionNotes = oclcNotAcceptableResponse.detail;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var oclcNotFoundResponse = response.Content.ReadAsAsync<OclcNotFoundResponse>(formatters).Result;

                    oclcSubmissionNotes = oclcNotFoundResponse.detail.description;
                }
                else
                {
                    oclcSubmissionNotes = response.Content.ReadAsStringAsync().Result;
                }

                Console.WriteLine(oclcSubmissionNotes);

                return false;
            }
        }
        public static bool GetOclc(OclcTokenResponse token)
        {
            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
                {
                    var baseAddress = new Uri(Config.OclcSvcUrl + $"worldcat/manage/bibs/1051969867");

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/marcxml+xml"));

                    HttpResponseMessage response = client.GetAsync("").Result;

                    return ProcessTheResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SaveOclc \"{Config.OclcSvcUrl}\" failed: {ex.Message}");
            }

            return false;
        }

        public static bool SaveOclc(OclcTokenResponse token)
        {
            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
                {
                    var baseAddress = new Uri(Config.OclcSvcUrl + "worldcat/manage/bibs");

                    client.BaseAddress = baseAddress;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/marcxml+xml"));

                    var content = new StringContent(
                        Config.Publication,
                        Encoding.UTF8,
                        "application/marcxml+xml");

                    HttpResponseMessage response = client.PostAsync("", content).Result;

                    return ProcessTheResponse(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SaveOclc \"{Config.OclcSvcUrl}\" failed: {ex.Message}");
            }

            return false;
        }

        static void Main(string[] args)
        {
            OclcTokenResponse token = GetOclcToken();

            if (token != null)
            {
                Console.WriteLine($"GetOclc() {GetOclc(token)}");

                Console.WriteLine($"SaveOclc() {SaveOclc(token)}");
            }

            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
