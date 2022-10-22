using Microsoft.Extensions.Configuration;
using ShortUrlWebApi.Business;
using ShortUrlWebApi.DataProvider;
using System.Net;
using System.Security.Policy;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlWebApi.BusinessImpl
{
    public class UrlBusiness : IUrlBusiness
    {
        private readonly IUrlDataHandler urlDataHandler;

        public UrlBusiness(IUrlDataHandler urlDataHandler)
        {
            this.urlDataHandler = urlDataHandler;
        }

        public string GetLongUrl(string ShortUrl)
        {
            return this.urlDataHandler.GetLongUrl(ShortUrl);
        }

        public string ShortenUrl(string url, int keyLength)
        {
            string newKey = null;

            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Trim().ToLower();
            }

            try
            {
                var uri = new Uri(url);
            }
            catch (Exception)
            {
                throw ;
            }

            if (this.HttpGetStatusCodeAsync(url).Result != HttpStatusCode.NotFound)
            {
                while (string.IsNullOrEmpty(newKey))
                {
                    newKey = Guid.NewGuid().ToString("N").Substring(0, keyLength == 0 ? 6 : keyLength).ToLower();
                }
            }

            return newKey;
        }

        public void SaveShortUrl(string shortUrl, string longUrl)
        {
            this.urlDataHandler.SaveShortUrl(shortUrl, longUrl);
        }

        public async Task<HttpStatusCode> HttpGetStatusCodeAsync(string Url)
        {
            try
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

                return response.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}
