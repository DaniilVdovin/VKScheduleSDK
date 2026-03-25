using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using VKScheduleSDK.NET.Models.Enums;

namespace VKScheduleSDK.NET.Core;

/// <summary>
/// Конвертер JSON для enum EventType
/// Сериализует/десериализует значения enum в русские строки из атрибута [Description]
/// </summary>
public class EventTypeJsonConverter : JsonConverter<EventType>
{
    /// <summary>
    /// Читает и десериализует русское название в значение enum
    /// </summary>
    /// <param name="reader">Json reader</param>
    /// <param name="typeToConvert">Тип для конвертации</param>
    /// <param name="options">Опции сериализации</param>
    /// <returns>Значение EventType</returns>
    public override EventType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var russianValue = reader.GetString();
        
        if (string.IsNullOrEmpty(russianValue))
            throw new JsonException("EventType value cannot be null or empty");

        foreach (var field in typeof(EventType).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute?.Description == russianValue)
                return (EventType)field.GetValue(null)!;
        }

        throw new JsonException($"Unknown EventType value: {russianValue}");
    }

    /// <summary>
    /// Пишет и сериализует значение enum в русскую строку
    /// </summary>
    /// <param name="writer">Json writer</param>
    /// <param name="value">Значение EventType</param>
    /// <param name="options">Опции сериализации</param>
    public override void Write(Utf8JsonWriter writer, EventType value, JsonSerializerOptions options)
    {
        // Получаем описание из атрибута [Description] через рефлексию
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        var russianValue = attribute?.Description ?? value.ToString();
        
        writer.WriteStringValue(russianValue);
    }
}