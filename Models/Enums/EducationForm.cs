using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Enums;

/// <summary>
/// Список форм обучения
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EducationForm
{
    /// <summary>
    /// Очная форма
    /// </summary>
    [Description("Очная")]
    FULLTIME,
    
    /// <summary>
    /// Заочная форма
    /// </summary>
    [Description("Заочная")]
    EXTRAMURAL,
    
    /// <summary>
    /// Очно-заочная форма
    /// </summary>
    [Description("Очно-заочная")]
    PARTTIME,
    
    /// <summary>
    /// Дистанционная форма
    /// </summary>
    [Description("Дистанционная")]
    REMOTE,
    
    /// <summary>
    /// Другая форма
    /// </summary>
    [Description("Другая")]
    OTHER
}