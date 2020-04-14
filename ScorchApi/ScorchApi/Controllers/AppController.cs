using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using ScorchApi.Interfaces;
using ScorchApi.Models.ViewModels;
using ScorchApi.Services;

namespace ScorchApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/App")]
    public class AppController : ApiController
    {
        private readonly IAppService _appService;
        public AppController(IAppService appService)
        {
            _appService = appService;
        }
        [HttpPost]
        public async Task Scorch(UserScorchHistoryModel obj)
        {
            await _appService.Scorch(obj);
        }
    }
}
