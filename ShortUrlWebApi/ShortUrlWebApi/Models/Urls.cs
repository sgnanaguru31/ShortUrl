using System;
using System.Security.Policy;

namespace ShortUrlWebApi.Models
{
    public class Urls
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
