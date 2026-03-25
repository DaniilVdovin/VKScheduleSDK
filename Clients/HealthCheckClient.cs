using VKScheduleSDK.NET.Core;

namespace VKScheduleSDK.NET.Clients;

/// <summary>
/// Клиент для проверки доступности API
/// </summary>
public class HealthCheckClient : ScheduleApiClient
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="HealthCheckClient"/>
    /// </summary>
    /// <param name="baseUrl">Базовый URL API</param>
    public HealthCheckClient(string? baseUrl = null) 
        : base(string.Empty, baseUrl)
    {
    }

    /// <summary>
    /// Проверка доступности API (health check)
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус ответа</returns>
    public async Task<Dictionary<string, string>?> PingAsync(
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.GetJsonAsync<Dictionary<string, string>>(
            "/ping",
            null,
            cancellationToken);
    }
}