using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Enums;

/// <summary>
/// Список уровней обучения
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EducationLevel
{
    /// <summary>
    /// Школа
    /// </summary>
    [Description("Школа")]
    SCHOOL,
    
    /// <summary>
    /// Среднее образование
    /// </summary>
    [Description("Среднее образование")]
    SECONDARY,
    
    /// <summary>
    /// Профессиональное образование
    /// </summary>
    [Description("Профессиональное образование")]
    VOCATIONAL,
    
    /// <summary>
    /// Бакалавриат
    /// </summary>
    [Description("Бакалавриат")]
    BACHELOR,
    
    /// <summary>
    /// Специалитет
    /// </summary>
    [Description("Специалитет")]
    SPECIALTY,
    
    /// <summary>
    /// Магистратура
    /// </summary>
    [Description("Магистратура")]
    MASTER,
    
    /// <summary>
    /// Другой уровень
    /// </summary>
    [Description("Другой")]
    OTHER
}