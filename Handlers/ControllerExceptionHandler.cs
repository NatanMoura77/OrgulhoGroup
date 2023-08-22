using Microsoft.AspNetCore.Mvc;
using VortiDex.Dtos.Responses;
using VortiDex.Exceptions.BadRequestExceptions;
using VortiDex.Exceptions.NotFoundExceptions;

namespace VortiDex.Handlers;

public static class ControllerExceptionHandler
{
    public static IActionResult HandleException(Exception exception)
    {
        ErrorDto errorDto = new(exception.Message);

        if (exception is NotFoundException) 
            return new NotFoundObjectResult(errorDto);

        if (exception is BadRequestException)
            return new BadRequestObjectResult(errorDto);

        return new ObjectResult(errorDto) { StatusCode = 500 };
    }
}
