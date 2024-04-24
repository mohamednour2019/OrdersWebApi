
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.Core.ServicesContracts;
using System.Net;
using System.Text.Json;


namespace Orders.Presentation.API.ControllerPresenter
{
    public class Presenter
    {
        public ContentResult contentResult;
        private ILogger _logger; 
        public Presenter(ILogger logger)
        {
            _logger = logger;
            contentResult = new ContentResult()
            {
                ContentType = "application/json"
            };
        }

        public async Task<IActionResult> Handle<TRequest, TResponse>(TRequest request
            , IGenericService<TRequest, TResponse> service)
        {
            var response= await service.performService(request);

            if (response is null||response is false)
            {
                contentResult.StatusCode = (int)HttpStatusCode.NotFound;
                contentResult.Content = JsonSerializer.Serialize("order not found!");
            }
            contentResult.StatusCode = (int)HttpStatusCode.OK;
            contentResult.Content = JsonSerializer.Serialize(response);
            return contentResult;
        }
    }
}
