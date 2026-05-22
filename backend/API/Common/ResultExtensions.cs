using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Common;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result.Value);

        return MapError(result.Error);
    }

    public static IActionResult ToCreatedResult<T>(this Result<T> result, string? location = null)
    {
        if (!result.IsSuccess)
            return MapError(result.Error);

        return location is null
            ? new ObjectResult(result.Value) { StatusCode = StatusCodes.Status201Created }
            : new CreatedResult(location, result.Value);
    }

    public static IActionResult ToNoContentResult<T>(this Result<T> result)
    {
        if (!result.IsSuccess)
            return MapError(result.Error);
        return new NoContentResult();
    }

    private static IActionResult MapError(Error error) => error.Code switch
    {
        "NotFound" => new NotFoundObjectResult(new { error = error.Message }),
        "Validation" => new BadRequestObjectResult(new { error = error.Message }),
        "Conflict" => new ConflictObjectResult(new { error = error.Message }),
        "Unauthorized" => new UnauthorizedObjectResult(new { error = error.Message }),
        "Forbidden" => new ObjectResult(new { error = error.Message }) { StatusCode = StatusCodes.Status403Forbidden },
        _ => new ObjectResult(new { error = error.Message }) { StatusCode = StatusCodes.Status500InternalServerError }
    };
}
