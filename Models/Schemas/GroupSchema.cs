using System.Text.Json.Serialization;
using VKScheduleSDK.NET.Models.Enums;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема академической группы
/// </summary>
public class GroupSchema
{
    /// <summary>
    /// ID группы
    /// </summary>
    [JsonPropertyName("groupId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string GroupId { get; set; }

    /// <summary>
    /// Код группы
    /// </summary>
    [JsonPropertyName("groupCode")]
    public string? GroupCode { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    [JsonPropertyName("groupName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string GroupName { get; set; }

    /// <summary>
    /// ID факультета
    /// </summary>
    [JsonPropertyName("facultyId")]
    public string? FacultyId { get; set; }

    /// <summary>
    /// ID специальности
    /// </summary>
    [JsonPropertyName("specialityCode")]
    public string? SpecialityCode { get; set; }

    /// <summary>
    /// Номер курса
    /// </summary>
    [JsonPropertyName("courseNumber")]
    public int? CourseNumber { get; set; }

    /// <summary>
    /// Форма обучения
    /// </summary>
    [JsonPropertyName("educationForm")]
    public EducationForm? EducationForm { get; set; }

    /// <summary>
    /// Уровень обучения
    /// </summary>
    [JsonPropertyName("educationLevel")]
    public EducationLevel? EducationLevel { get; set; }
}