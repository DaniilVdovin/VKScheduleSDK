using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема корпуса
/// </summary>
public class BuildingSchema
{
    /// <summary>
    /// ID здания
    /// </summary>
    [JsonPropertyName("buildingId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required string BuildingId { get; set; }

    /// <summary>
    /// Наименование здания (учебный корпус)
    /// </summary>
    [JsonPropertyName("buildingName")]
    public string? BuildingName { get; set; }

    /// <summary>
    /// Полный адрес здания
    /// </summary>
    [JsonPropertyName("buildingAddressText")]
    public string? BuildingAddressText { get; set; }

    /// <summary>
    /// Регион
    /// </summary>
    [JsonPropertyName("region")]
    public string? Region { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Улица
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// Микрорайон
    /// </summary>
    [JsonPropertyName("microdistrict")]
    public string? Microdistrict { get; set; }

    /// <summary>
    /// Дом
    /// </summary>
    [JsonPropertyName("house")]
    public string? House { get; set; }

    /// <summary>
    /// Строение
    /// </summary>
    [JsonPropertyName("structure")]
    public string? Structure { get; set; }

    /// <summary>
    /// Корпус
    /// </summary>
    [JsonPropertyName("corps")]
    public string? Corps { get; set; }

    /// <summary>
    /// Подъезд
    /// </summary>
    [JsonPropertyName("entrance")]
    public string? Entrance { get; set; }

    /// <summary>
    /// Долгота
    /// </summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    /// <summary>
    /// Широта
    /// </summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }
}