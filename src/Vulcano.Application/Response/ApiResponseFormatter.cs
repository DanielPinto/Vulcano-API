

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vulcano.Domain.Interfaces;
using Vulcano.Domain.Utils;

namespace Vulcano.Application.Response;

public class ApiResponseFormatter : IApiResponseFormatter
{
    public IActionResult FormatResponse<T>(Result<T> result, HttpRequest request, int? totalItems = null, int? page = null, int? size = null)
    {
        if (result.IsFailure)
        {
            return new ObjectResult(new
            {
                result.Errors,
                Code = result.ErrorCode.ToString()
            })
            {
                StatusCode = result.StatusCode
            };
        }

        // Paginação automática para listas com mais de 100 itens
        if (result.Data is IEnumerable<object> list && totalItems.HasValue && totalItems > 100)
        {
            return new OkObjectResult(new PagedResponse<object>(
                data: list,
                currentPage: page ?? 1,
                totalItems: totalItems.Value,
                pageSize: size ?? 10
            ));
        }

        return new OkObjectResult(result.Data);
    }

    public IActionResult FormatCreated<T>(Result<T> result, HttpRequest request, HttpResponse response, Guid routeId)
    {
        if (result.IsFailure)
        {
            return new ObjectResult(new
            {
                Errors = result.Errors,
                Code = result.ErrorCode.ToString()
            })
            {
                StatusCode = result.StatusCode
            };
        }

        string locationUrl = $"{request.Scheme}://{request.Host}{request.Path}/{routeId}";
        response.Headers.Append("Location", locationUrl);
        return new StatusCodeResult(201);
    }

    public IActionResult FormatDeleted(string message = "Resource deleted successfully.")
    {
        return new OkObjectResult(new
        {
            success = true,
            message
        });
    }

}
