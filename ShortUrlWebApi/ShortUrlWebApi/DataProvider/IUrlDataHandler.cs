namespace ShortUrlWebApi.DataProvider
{
    public interface IUrlDataHandler
    {
        public string GetLongUrl(string ShortUrl);
        public void SaveShortUrl(string shortUrl, string longUrl);
    }
}
