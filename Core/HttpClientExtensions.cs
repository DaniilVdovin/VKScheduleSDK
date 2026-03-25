using System.Text;
using System.Text.Json;

namespace VKScheduleSDK.NET.Core;

/// <summary>
/// Методы расширения для HttpClient
/// </summary>
public static class HttpClientExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Отправляет POST запрос с JSON телом
    /// </summary>
    /// <typeparam name="TRequest">Тип запроса</typeparam>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="client">Экземпляр HttpClient</param>
    /// <param name="requestUri">URI запроса</param>
    /// <param name="content">Данные запроса</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Десериализованный ответ</returns>
    public static async Task<TResponse?> PostJsonAsync<TRequest, TResponse>(
        this HttpClient client,
        string requestUri,
        TRequest content,
        string? bearerToken = null,
        CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(content, _jsonOptions);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        if (!string.IsNullOrEmpty(bearerToken))
        {
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        var response = await client.PostAsync(requestUri, httpContent, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }

    /// <summary>
    /// Отправляет POST запрос с JSON массивом
    /// </summary>
    /// <typeparam name="TItem">Тип элемента массива</typeparam>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="client">Экземпляр HttpClient</param>
    /// <param name="requestUri">URI запроса</param>
    /// <param name="items">Массив данных</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Десериализованный ответ</returns>
    public static async Task<TResponse?> PostJsonArrayAsync<TItem, TResponse>(
        this HttpClient client,
        string requestUri,
        IEnumerable<TItem> items,
        string? bearerToken = null,
        CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(items, _jsonOptions);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        if (!string.IsNullOrEmpty(bearerToken))
        {
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        var response = await client.PostAsync(requestUri, httpContent, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            return default;
        }
        
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }

    /// <summary>
    /// Отправляет PUT запрос с JSON телом
    /// </summary>
    /// <typeparam name="TRequest">Тип запроса</typeparam>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="client">Экземпляр HttpClient</param>
    /// <param name="requestUri">URI запроса</param>
    /// <param name="content">Данные запроса</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Десериализованный ответ</returns>
    public static async Task<TResponse?> PutJsonAsync<TRequest, TResponse>(
        this HttpClient client,
        string requestUri,
        TRequest content,
        string? bearerToken = null,
        CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(content, _jsonOptions);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        if (!string.IsNullOrEmpty(bearerToken))
        {
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        var response = await client.PutAsync(requestUri, httpContent, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }

    /// <summary>
    /// Отправляет DELETE запрос
    /// </summary>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="client">Экземпляр HttpClient</param>
    /// <param name="requestUri">URI запроса</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Десериализованный ответ</returns>
    public static async Task<TResponse?> DeleteAsync<TResponse>(
        this HttpClient client,
        string requestUri,
        string? bearerToken = null,
        CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrEmpty(bearerToken))
        {
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        var response = await client.DeleteAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            return default;
        }
        
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }

    /// <summary>
    /// Отправляет GET запрос
    /// </summary>
    /// <typeparam name="TResponse">Тип ответа</typeparam>
    /// <param name="client">Экземпляр HttpClient</param>
    /// <param name="requestUri">URI запроса</param>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Десериализованный ответ</returns>
    public static async Task<TResponse?> GetJsonAsync<TResponse>(
        this HttpClient client,
        string requestUri,
        string? bearerToken = null,
        CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrEmpty(bearerToken))
        {
            client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        var response = await client.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(responseContent, _jsonOptions);
    }
}