using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ScorchApi.Interfaces;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Controllers
{
    [Authorize]
    public class SetupController : ApiController
    {
        private readonly ISetupService _setupService;
        public SetupController(ISetupService setupService)
        {
            _setupService = setupService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetSearchSettings() => Ok(await _setupService.GetSearchSettings(User.Identity.GetUserId()));

        [HttpPut]
        public async Task SetSearchSetting(SearchOptionsModel obj) => 
            await _setupService.SetSearchSetting(User.Identity.GetUserId(), obj);

        [HttpPut]
        public async Task SetSearchDistanceSetting([FromUri]double value) => 
            await _setupService.SetSearchDistanceSetting(User.Identity.GetUserId(), value);
    }
}
