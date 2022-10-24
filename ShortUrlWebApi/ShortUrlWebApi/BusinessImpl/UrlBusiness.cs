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

        private readonly IHttpClientBusiness httpClientBusiness;

        public UrlBusiness(IUrlDataHandler urlDataHandler, IHttpClientBusiness httpClientBusiness)
        {
            this.urlDataHandler = urlDataHandler;
            this.httpClientBusiness = httpClientBusiness;
        }

        public async Task<string> GetLongUrlAsync(string ShortUrl)
        {
            return await this.urlDataHandler.GetLongUrlAsync(ShortUrl);
        }

        public async Task<string> ShortenUrlAsync(string url, int keyLength)
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
            catch (Exception ex)
            {
                throw ex;
            }

            if (await this.httpClientBusiness.ValidateURLAsync(url) && (string.IsNullOrEmpty(newKey)))
            {
                newKey = Guid.NewGuid().ToString("N").Substring(0, keyLength == 0 ? 6 : keyLength).ToLower();
            }

            return newKey;
        }

        public async Task SaveShortUrlAsync(string shortUrl, string longUrl)
        {
            await this.urlDataHandler.SaveShortUrlAsync(shortUrl, longUrl);
        }
    }
}
