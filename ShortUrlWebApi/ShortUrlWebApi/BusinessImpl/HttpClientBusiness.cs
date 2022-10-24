using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ShortUrlWebApi.Business;

namespace ShortUrlWebApi.BusinessImpl
{
    public class HttpClientBusiness : IHttpClientBusiness
    {
        public async Task<bool> ValidateURLAsync(string Url)
        {
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync(Url, HttpCompletionOption.ResponseHeadersRead);

            string text = null;

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var bytes = new byte[10];
                var bytesread = stream.Read(bytes, 0, 10);
                stream.Close();

                text = Encoding.UTF8.GetString(bytes);

                Console.WriteLine(text);
            }

            return response.StatusCode != HttpStatusCode.NotFound;
        }
    }
}
