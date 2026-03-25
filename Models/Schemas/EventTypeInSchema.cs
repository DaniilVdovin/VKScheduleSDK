using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема типа события расписания
/// </summary>
public class EventTypeInSchema
{
    /// <summary>
    /// Уникальный ID типа события для вуза
    /// </summary>
    [JsonPropertyName("eventTypeId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string EventTypeId { get; set; }

    /// <summary>
    /// Строковое значение типа события (например 'Встреча')
    /// </summary>
    [JsonPropertyName("eventType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string EventType { get; set; }

    /// <summary>
    /// Отображаемое название (alias)
    /// </summary>
    [JsonPropertyName("eventTypeAlias")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string EventTypeAlias { get; set; }
}