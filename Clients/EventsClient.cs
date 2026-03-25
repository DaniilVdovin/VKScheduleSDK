using VKScheduleSDK.NET.Core;
using VKScheduleSDK.NET.Models.Schemas;

namespace VKScheduleSDK.NET.Clients;

/// <summary>
/// Клиент для методов работы с отдельными событиями расписания
/// </summary>
public class EventsClient : ScheduleApiClient
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="EventsClient"/>
    /// </summary>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API</param>
    public EventsClient(string bearerToken, string? baseUrl = null) 
        : base(bearerToken, baseUrl)
    {
    }

    /// <summary>
    /// Создание нового события расписания
    /// </summary>
    /// <param name="eventSchema">Данные события</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Созданное событие</returns>
    public async Task<EventResponseSchema?> CreateEventAsync(
        EventSchema eventSchema,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonAsync<EventSchema, EventResponseSchema>(
            "/v1/events",
            eventSchema,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Обновление существующего события расписания
    /// </summary>
    /// <param name="eventSchema">Данные события</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Обновленное событие</returns>
    public async Task<EventResponseSchema?> UpdateEventAsync(
        EventSchema eventSchema,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PutJsonAsync<EventSchema, EventResponseSchema>(
            "/v1/events",
            eventSchema,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Удаление события расписания по ID
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат удаления</returns>
    public async Task<Dictionary<string, string>?> DeleteEventAsync(
        string eventId,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.DeleteAsync<Dictionary<string, string>>(
            $"/v1/events/{eventId}",
            BearerToken,
            cancellationToken);
    }
}