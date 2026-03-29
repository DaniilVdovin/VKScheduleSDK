using VKScheduleSDK.NET.Core;

namespace VKScheduleSDK.NET.Clients;

/// <summary>
/// Основной клиент для работы с API расписания VK Apps
/// Объединяет все функциональные клиенты в единый интерфейс
/// </summary>
public class VKScheduleClient : IDisposable
{
    readonly private string _bearerToken;
    readonly private string _baseUrl;
    private bool _disposed;

    private ImportClient? _importClient;
    private EventsClient? _eventsClient;
    private InstitutionClient? _institutionClient;
    private HealthCheckClient? _healthCheckClient;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="VKScheduleClient"/>
    /// </summary>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API (по умолчанию: https://schedule.vk-apps.com)</param>
    public VKScheduleClient(string bearerToken, string? baseUrl = null)
    {
        _bearerToken = bearerToken;
        _baseUrl = baseUrl ?? ScheduleApiClient.DefaultBaseUrl;
    }

    /// <summary>
    /// Клиент для массовых операций импорта/обновления данных
    /// </summary>
    public ImportClient Import => _importClient ??= new ImportClient(_bearerToken, _baseUrl);

    /// <summary>
    /// Клиент для работы с отдельными событиями расписания
    /// </summary>
    public EventsClient Events => _eventsClient ??= new EventsClient(_bearerToken, _baseUrl);

    /// <summary>
    /// Клиент для работы с настройками организации
    /// </summary>
    public InstitutionClient Institution => _institutionClient ??= new InstitutionClient(_bearerToken, _baseUrl);

    /// <summary>
    /// Клиент для проверки доступности API
    /// </summary>
    public HealthCheckClient HealthCheck => _healthCheckClient ??= new HealthCheckClient(_baseUrl);

    /// <summary>
    /// Освобождает ресурсы
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Освобождает управляемые и неуправляемые ресурсы
    /// </summary>
    /// <param name="disposing">true для освобождения управляемых ресурсов</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _importClient?.Dispose();
                _eventsClient?.Dispose();
                _institutionClient?.Dispose();
                _healthCheckClient?.Dispose();
            }
            _disposed = true;
        }
    }
}