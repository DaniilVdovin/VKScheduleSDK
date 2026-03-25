using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема ошибки валидации на уровне HTTP
/// </summary>
public class HTTPValidationError
{
    /// <summary>
    /// Детали ошибок валидации
    /// </summary>
    [JsonPropertyName("detail")]
    public List<ValidationError>? Detail { get; set; }
}