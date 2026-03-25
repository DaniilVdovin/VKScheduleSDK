using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема ошибки валидации
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Путь к полю с ошибкой
    /// </summary>
    [JsonPropertyName("loc")]
    public required List<object> Loc { get; set; }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    [JsonPropertyName("msg")]
    public required string Msg { get; set; }

    /// <summary>
    /// Тип ошибки
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Входное значение, вызвавшее ошибку
    /// </summary>
    [JsonPropertyName("input")]
    public object? Input { get; set; }

    /// <summary>
    /// Контекст ошибки
    /// </summary>
    [JsonPropertyName("ctx")]
    public Dictionary<string, object>? Ctx { get; set; }
}