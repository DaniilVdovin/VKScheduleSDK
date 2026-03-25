using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема ответа после загрузки иконки организации
/// </summary>
public class InstitutionIconUploadResponse
{
    /// <summary>
    /// URL загруженной иконки
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}