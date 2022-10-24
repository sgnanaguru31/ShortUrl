using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortUrlWebApi.Business;
using ShortUrlWebApi.Models;
using System.Threading.Tasks;

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
        public async Task<string> Post([FromBody] LongUrlPost url)
        {
            var shortKey = await this.urlBusiness.ShortenUrlAsync(url.LongUrl, url.KeyLength);
            var shortUrl = $"{Request.Scheme}://{Request.Host}/{shortKey}";
            await this.urlBusiness.SaveShortUrlAsync(shortUrl, url.LongUrl);
            return shortUrl;
        }

        [HttpGet]
        [Route("{key}")]
        public async Task GetAsync(string key)
        {
            var shortUrl = $"{Request.Scheme}://{Request.Host}/{key}";
            Response.Redirect(await this.urlBusiness.GetLongUrlAsync(shortUrl));
        }
    }
}
