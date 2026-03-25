using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема преподавателя
/// </summary>
public class TeacherSchema
{
    /// <summary>
    /// ID преподавателя
    /// </summary>
    [JsonPropertyName("teacherId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string TeacherId { get; set; }

    /// <summary>
    /// ФИО преподавателя
    /// </summary>
    [JsonPropertyName("teacherName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string TeacherName { get; set; }

    /// <summary>
    /// ФИО преподавателя полное
    /// </summary>
    [JsonPropertyName("teacherFullName")]
    public string? TeacherFullName { get; set; }

    /// <summary>
    /// Должность преподавателя
    /// </summary>
    [JsonPropertyName("teacherRank")]
    public string? TeacherRank { get; set; }

    /// <summary>
    /// ID кафедр, к которым относится преподаватель
    /// </summary>
    [JsonPropertyName("departmentIds")]
    public List<string>? DepartmentIds { get; set; }
}