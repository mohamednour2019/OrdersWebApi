using Microsoft.AspNetCore.Mvc;
using Orders.Presentation.API.ControllerPresenter;
namespace Orders.Presentation.API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        protected ILogger _logger;
        protected Presenter _presenter;
        protected IHttpContextAccessor _contextAccessor;
        public BaseController(ILogger logger)
        {
            _presenter = new Presenter( logger);
            _logger = logger;
        }
    }
    
}
