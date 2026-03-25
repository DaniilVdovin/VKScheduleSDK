using System.Text.Json.Serialization;
using VKScheduleSDK.NET.Models.Enums;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема события расписания
/// </summary>
public class EventSchema
{
    /// <summary>
    /// ID события
    /// </summary>
    [JsonPropertyName("eventId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string EventId { get; set; }

    /// <summary>
    /// Наименование события
    /// </summary>
    [JsonPropertyName("eventName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string EventName { get; set; }

    /// <summary>
    /// Дата и время начала события (unix timestamp)
    /// </summary>
    [JsonPropertyName("eventDateStart")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public long EventDateStart { get; set; }

    /// <summary>
    /// Дата и время окончания события (unix timestamp)
    /// </summary>
    [JsonPropertyName("eventDateEnd")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public long EventDateEnd { get; set; }

    /// <summary>
    /// Дата окончания повторяющегося события (unix timestamp)
    /// </summary>
    [JsonPropertyName("recurrenceDateEnd")]
    public long? RecurrenceDateEnd { get; set; }

    /// <summary>
    /// Количество недель в цикле для повторения. 0 - событие не повторяется. 
    /// 1 - повторяется каждую неделю, 2 - повторяется каждые 2 недели (для реализации четных/нечетных недель)
    /// </summary>
    [JsonPropertyName("weeklyRecurrence")]
    public int WeeklyRecurrence { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required EventType EventType { get; set; }

    /// <summary>
    /// ID подгруппы
    /// </summary>
    [JsonPropertyName("subGroupId")]
    public string? SubGroupId { get; set; }

    /// <summary>
    /// ID аудиторий в которых происходит событие
    /// </summary>
    [JsonPropertyName("roomIds")]
    public List<string>? RoomIds { get; set; }

    /// <summary>
    /// ID преподавателей участвующих в этом событии
    /// </summary>
    [JsonPropertyName("teacherIds")]
    public List<string>? TeacherIds { get; set; }

    /// <summary>
    /// ID групп участвующих в этом событии
    /// </summary>
    [JsonPropertyName("groupId")]
    public List<string>? GroupId { get; set; }
}