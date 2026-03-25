using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема кафедры
/// </summary>
public class DepartmentSchema
{
    /// <summary>
    /// ID кафедры
    /// </summary>
    [JsonPropertyName("departmentId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string DepartmentId { get; set; }

    /// <summary>
    /// Наименование кафедры
    /// </summary>
    [JsonPropertyName("departmentName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string DepartmentName { get; set; }
}