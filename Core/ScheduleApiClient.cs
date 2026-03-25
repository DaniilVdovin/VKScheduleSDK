namespace VKScheduleSDK.NET.Core;

/// <summary>
/// Базовый класс клиента для работы с API расписания VK Apps
/// </summary>
public class ScheduleApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string? _bearerToken;
    private bool _disposed;

    /// <summary>
    /// Базовый URL API по умолчанию
    /// </summary>
    public const string DefaultBaseUrl = "https://schedule.vk-apps.com";

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ScheduleApiClient"/>
    /// </summary>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API (по умолчанию: https://schedule.vk-apps.com)</param>
    public ScheduleApiClient(string bearerToken, string? baseUrl = null)
    {
        _bearerToken = bearerToken;
        _baseUrl = baseUrl ?? DefaultBaseUrl;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl)
        };
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ScheduleApiClient"/> с существующим HttpClient
    /// </summary>
    /// <param name="httpClient">Экземпляр HttpClient</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API</param>
    public ScheduleApiClient(HttpClient httpClient, string bearerToken, string baseUrl)
    {
        _httpClient = httpClient;
        _bearerToken = bearerToken;
        _baseUrl = baseUrl;
    }

    /// <summary>
    /// Получает экземпляр HttpClient
    /// </summary>
    protected HttpClient HttpClient => _httpClient;

    /// <summary>
    /// Получает Bearer токен
    /// </summary>
    protected string? BearerToken => _bearerToken;

    /// <summary>
    /// Получает базовый URL API
    /// </summary>
    protected string BaseUrl => _baseUrl;

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
                _httpClient?.Dispose();
            }
            _disposed = true;
        }
    }
}