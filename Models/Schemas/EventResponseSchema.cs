using System.Text.Json.Serialization;
using VKScheduleSDK.NET.Models.Enums;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема ответа методов, редактирующих события в расписании
/// </summary>
public class EventResponseSchema
{
    /// <summary>
    /// ID события
    /// </summary>
    [JsonPropertyName("eventId")]
    public required string EventId { get; set; }

    /// <summary>
    /// Наименование события
    /// </summary>
    [JsonPropertyName("eventName")]
    public required string EventName { get; set; }

    /// <summary>
    /// Дата и время начала события (unix timestamp)
    /// </summary>
    [JsonPropertyName("eventDateStart")]
    public long EventDateStart { get; set; }

    /// <summary>
    /// Дата и время окончания события (unix timestamp)
    /// </summary>
    [JsonPropertyName("eventDateEnd")]
    public long EventDateEnd { get; set; }

    /// <summary>
    /// Дата окончания повторяющегося события (unix timestamp)
    /// </summary>
    [JsonPropertyName("recurrenceDateEnd")]
    public long? RecurrenceDateEnd { get; set; }

    /// <summary>
    /// Ссылка на видео-звонок
    /// </summary>
    [JsonPropertyName("eventLinkCall")]
    public string? EventLinkCall { get; set; }

    /// <summary>
    /// Ссылка на учебные материалы
    /// </summary>
    [JsonPropertyName("eventLinkMaterials")]
    public string? EventLinkMaterials { get; set; }

    /// <summary>
    /// Тип события
    /// </summary>
    [JsonPropertyName("eventType")]
    public required EventType EventType { get; set; }
}