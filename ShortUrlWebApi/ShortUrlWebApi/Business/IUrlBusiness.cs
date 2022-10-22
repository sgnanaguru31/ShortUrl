namespace ShortUrlWebApi.Business
{
    public interface IUrlBusiness
    {
        public string GetLongUrl(string ShortUrl);
        public string ShortenUrl(string url, int keyLength);
        public void SaveShortUrl(string shortUrl, string longUrl);
    }
}
