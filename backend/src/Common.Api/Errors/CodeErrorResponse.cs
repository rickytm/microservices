
using Newtonsoft.Json;

namespace Common.Api.Errors;

public class CodeErrorResponse
{
    [JsonProperty(PropertyName = "statusCode")]
    public int StatusCode { get; set; }
    [JsonProperty(PropertyName = "message")]
    public string[]? Message { get; set; }

    public CodeErrorResponse(int statusCode, string[]? message = null)
    {
        StatusCode = statusCode;
        if (message is null)
        {
            Message = new string[0];
            string text = GetDefaultMessageStatusCode(statusCode);
            Message[0] = text;
        }
        else
        {
            Message = message;
        }
    }

    private string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "El request enviado tiene errores",
            401 => "No tienes credenciales válidas de autenticación para este recurso",
            403 => "No tienes permisos para este recurso",
            404 => "No se encontró el recurso solicitado",
            500 => "Se produjeron errores en el servidor",
            _ => string.Empty
        };
    }
}


