using System.Net;
using System.Threading.Tasks;

namespace ShortUrlWebApi.Business
{
    public interface IHttpClientBusiness
    {
        Task<bool> ValidateURLAsync(string Url);
    }
}
