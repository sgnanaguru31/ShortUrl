using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortUrlWebApi.Business;
using ShortUrlWebApi.Models;

namespace ShortUrlWebApi.Controllers
{
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly ILogger<ShortUrlController> _logger;

        private readonly IUrlBusiness urlBusiness;

        public ShortUrlController(ILogger<ShortUrlController> logger, IUrlBusiness urlBusiness)
        {
            _logger = logger;
            this.urlBusiness = urlBusiness;
        }

        [HttpPost]
        [Route("shorten")]
        public string Post([FromBody] LongUrlPost url)
        {
            var shortKey = this.urlBusiness.ShortenUrl(url.LongUrl, url.KeyLength);
            var shortUrl = $"{Request.Scheme}://{Request.Host}/{shortKey}";
            this.urlBusiness.SaveShortUrl(shortUrl, url.LongUrl);
            return shortUrl;
        }

        [HttpGet]
        [Route("{key}")]
        public void Get(string key)
        {
            var shortUrl = $"{Request.Scheme}://{Request.Host}/{key}";
            Response.Redirect(this.urlBusiness.GetLongUrl(shortUrl));
        }
    }
}
