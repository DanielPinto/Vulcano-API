using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vulcano.Domain.Utils;

namespace Vulcano.Domain.Interfaces
{
    public interface IApiResponseFormatter
    {
        IActionResult FormatResponse<T>(Result<T> result, HttpRequest request, int? totalItems = null, int? page = null, int? size = null);
        IActionResult FormatCreated<T>(Result<T> result, HttpRequest request, HttpResponse response, Guid routeId);
        IActionResult FormatDeleted(string message = "Resource deleted successfully.");
    }
}