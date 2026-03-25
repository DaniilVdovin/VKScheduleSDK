using System.ComponentModel;
using System.Text.Json.Serialization;
using VKScheduleSDK.NET.Core;

namespace VKScheduleSDK.NET.Models.Enums;

/// <summary>
/// Список типов событий расписания
/// </summary>
[JsonConverter(typeof(EventTypeJsonConverter))]
public enum EventType
{
    /// <summary>
    /// Встреча
    /// </summary>
    [Description("Встреча")]
    Meeting,
    
    /// <summary>
    /// Дифференцированный зачет
    /// </summary>
    [Description("Дифференцированный зачет")]
    DifferentiatedTest,
    
    /// <summary>
    /// Зачет
    /// </summary>
    [Description("Зачет")]
    Test,
    
    /// <summary>
    /// Иное
    /// </summary>
    [Description("Иное")]
    Other,
    
    /// <summary>
    /// Комиссия
    /// </summary>
    [Description("Комиссия")]
    Commission,
    
    /// <summary>
    /// Контроль самостоятельной работы
    /// </summary>
    [Description("Контроль самостоятельной работы")]
    IndependentWorkControl,
    
    /// <summary>
    /// Консультация
    /// </summary>
    [Description("Консультация")]
    Consultation,
    
    /// <summary>
    /// Лабораторная работа
    /// </summary>
    [Description("Лабораторная работа")]
    LaboratoryWork,
    
    /// <summary>
    /// Лекция
    /// </summary>
    [Description("Лекция")]
    Lecture,
    
    /// <summary>
    /// Окно
    /// </summary>
    [Description("Окно")]
    Window,
    
    /// <summary>
    /// Пересдача
    /// </summary>
    [Description("Пересдача")]
    Retake,
    
    /// <summary>
    /// Практика
    /// </summary>
    [Description("Практика")]
    Internship,
    
    /// <summary>
    /// Практическое занятие
    /// </summary>
    [Description("Практическое занятие")]
    PracticalClass,
    
    /// <summary>
    /// Семинар
    /// </summary>
    [Description("Семинар")]
    Seminar,
    
    /// <summary>
    /// Экзамен
    /// </summary>
    [Description("Экзамен")]
    Exam,
    
    /// <summary>
    /// Курсовая работа
    /// </summary>
    [Description("Курсовая работа")]
    Coursework,
    
    /// <summary>
    /// Выпускная работа
    /// </summary>
    [Description("Выпускная работа")]
    GraduationThesis,
    
    /// <summary>
    /// Научно-исследовательская работа
    /// </summary>
    [Description("Научно-исследовательская работа")]
    ResearchWork,
    
    /// <summary>
    /// Итоговая аттестация
    /// </summary>
    [Description("Итоговая аттестация")]
    FinalCertification,
    
    /// <summary>
    /// Конференция
    /// </summary>
    [Description("Конференция")]
    Conference,
    
    /// <summary>
    /// Экскурсия
    /// </summary>
    [Description("Экскурсия")]
    Excursion
}