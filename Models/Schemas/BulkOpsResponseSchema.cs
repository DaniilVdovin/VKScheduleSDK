using System.Text.Json.Serialization;

namespace VKScheduleSDK.NET.Models.Schemas;

/// <summary>
/// Схема ответа методов, принимающих массив данных
/// </summary>
public class BulkOpsResponseSchema
{
    /// <summary>
    /// Количество принятых записей
    /// </summary>
    [JsonPropertyName("acceptedItemsCount")]
    public int AcceptedItemsCount { get; set; }

    /// <summary>
    /// Количество записей, подлежащих удалению
    /// </summary>
    [JsonPropertyName("deletedCount")]
    public int DeletedCount { get; set; }

    /// <summary>
    /// Количество записей, подлежащих обновлению
    /// </summary>
    [JsonPropertyName("updatedCount")]
    public int UpdatedCount { get; set; }

    /// <summary>
    /// Количество записей, подлежащих созданию
    /// </summary>
    [JsonPropertyName("createdCount")]
    public int CreatedCount { get; set; }

    /// <summary>
    /// Преобразует класс в удобную структуру для вывода в консоль
    /// </summary>
    /// <returns>Строку с информацией о результатах отправки</returns>
    public override string ToString()
    {
        return $"""
                ═══════════════════════════════════════
                📊 Результат массовой операции
                ═══════════════════════════════════════
                Принято:      {AcceptedItemsCount,5}
                Удалено:      {DeletedCount,5}
                Обновлено:    {UpdatedCount,5}
                Создано:      {CreatedCount,5}
                ═══════════════════════════════════════
                """;
    }
}