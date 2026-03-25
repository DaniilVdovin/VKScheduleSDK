using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема подгруппы
/// </summary>
public class SubGroupSchema
{
    /// <summary>
    /// ID подгруппы
    /// </summary>
    [JsonPropertyName("subGroupId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string SubGroupId { get; set; }

    /// <summary>
    /// Код подгруппы (это поле будет отображаться в интерфейсе)
    /// </summary>
    [JsonPropertyName("subGroupCode")]
    public string? SubGroupCode { get; set; }

    /// <summary>
    /// Наименование подгруппы
    /// </summary>
    [JsonPropertyName("subGroupName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string SubGroupName { get; set; }

    /// <summary>
    /// ID групп, к которым относится подгруппа
    /// </summary>
    [JsonPropertyName("groupIds")]
    public List<string>? GroupIds { get; set; }
}