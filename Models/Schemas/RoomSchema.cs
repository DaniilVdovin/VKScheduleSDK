using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема аудитории
/// </summary>
public class RoomSchema
{
    /// <summary>
    /// ID аудитории
    /// </summary>
    [JsonPropertyName("roomId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string RoomId { get; set; }

    /// <summary>
    /// Наименование аудитории
    /// </summary>
    [JsonPropertyName("roomName")]
    public string? RoomName { get; set; }

    /// <summary>
    /// Этаж
    /// </summary>
    [JsonPropertyName("floor")]
    public int? Floor { get; set; }

    /// <summary>
    /// ID здания
    /// </summary>
    [JsonPropertyName("buildingId")]
    public string? BuildingId { get; set; }
}