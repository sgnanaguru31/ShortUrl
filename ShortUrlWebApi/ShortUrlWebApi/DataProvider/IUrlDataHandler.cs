using System.Threading.Tasks;

namespace ShortUrlWebApi.DataProvider
{
    public interface IUrlDataHandler
    {
        Task<string> GetLongUrlAsync(string ShortUrl);

        Task SaveShortUrlAsync(string shortUrl, string longUrl);
    }
}
