using System.Threading.Tasks;

namespace ShortUrlWebApi.Business
{
    public interface IUrlBusiness
    {
        Task<string> GetLongUrlAsync(string ShortUrl);

        Task<string> ShortenUrlAsync(string url, int keyLength);

        Task SaveShortUrlAsync(string shortUrl, string longUrl);
    }
}
