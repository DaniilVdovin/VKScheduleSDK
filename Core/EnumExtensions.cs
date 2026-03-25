using System.ComponentModel;
using System.Reflection;
using VKScheduleSDK.NET.Models.Enums;

namespace VKScheduleSDK.NET.Core;

/// <summary>
/// Методы расширения для работы с перечислениями и атрибутами [Description]
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Получает значение атрибута [Description] для значения перечисления.
    /// Если атрибут не задан — возвращает имя значения.
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    /// <param name="value">Значение перечисления</param>
    /// <returns>Описание из атрибута или имя значения</returns>
    public static string GetDescription<T>(this T value) where T : Enum
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    /// <summary>
    /// Получает русское название типа события (алиас для GetDescription)
    /// </summary>
    /// <param name="eventType">Значение EventType</param>
    /// <returns>Русское название типа события</returns>
    public static string GetRussianName(this EventType eventType) => 
        eventType.GetDescription();

    /// <summary>
    /// Получает значение перечисления по описанию из атрибута [Description]
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    /// <param name="description">Описание для поиска</param>
    /// <param name="ignoreCase">Игнорировать регистр при сравнении</param>
    /// <returns>Значение перечисления или null если не найдено</returns>
    public static T? FromDescription<T>(string description, bool ignoreCase = false) where T : Enum,new()
    {
        if (string.IsNullOrEmpty(description))
            return new T();

        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute?.Description.Equals(description, comparison) == true)
                return (T)field.GetValue(null)!;
        }
        return new T();
    }

    /// <summary>
    /// Получает значение EventType по русскому названию
    /// </summary>
    /// <param name="russianName">Русское название типа события</param>
    /// <returns>Значение EventType или null если не найдено</returns>
    public static EventType? FromRussianName(string russianName) => 
        FromDescription<EventType>(russianName);

    /// <summary>
    /// Получает список всех описаний значений перечисления
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    /// <returns>Массив описаний</returns>
    public static string[] GetAllDescriptions<T>() where T : struct, Enum => 
        Enum.GetValues<T>().Select(e => e.GetDescription()).ToArray();

    /// <summary>
    /// Получает список всех русских названий типов событий
    /// </summary>
    /// <returns>Массив строк с русскими названиями</returns>
    public static string[] GetAllRussianEventTypes() => 
        GetAllDescriptions<EventType>();

    /// <summary>
    /// Возвращает все значения перечисления с их описаниями
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    /// <returns>Словарь: значение → описание</returns>
    public static Dictionary<T, string> GetAllWithDescriptions<T>() where T : struct, Enum => 
        Enum.GetValues<T>().ToDictionary(v => v, v => v.GetDescription());
}