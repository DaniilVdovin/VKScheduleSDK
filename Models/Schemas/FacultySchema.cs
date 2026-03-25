using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема факультета
/// </summary>
public class FacultySchema
{
    /// <summary>
    /// ID факультета
    /// </summary>
    [JsonPropertyName("facultyId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string FacultyId { get; set; }

    /// <summary>
    /// Код факультета
    /// </summary>
    [JsonPropertyName("facultyCode")]
    public string? FacultyCode { get; set; }

    /// <summary>
    /// Наименование факультета
    /// </summary>
    [JsonPropertyName("facultyName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string FacultyName { get; set; }
}