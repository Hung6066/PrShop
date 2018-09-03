using PrShop.Service;
using PrShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace ProShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;

        public HomeController(IErrorService errorService) : base(errorService)
        {
            _errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, Hung Member";
        }
    }
}