using VKScheduleSDK.NET.Core;
using VKScheduleSDK.NET.Models.Schemas;

namespace VKScheduleSDK.NET.Clients;

/// <summary>
/// Клиент для методов работы с организацией
/// </summary>
public class InstitutionClient : ScheduleApiClient
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="InstitutionClient"/>
    /// </summary>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API</param>
    public InstitutionClient(string bearerToken, string? baseUrl = null) 
        : base(bearerToken, baseUrl)
    {
    }

    /// <summary>
    /// Загрузка иконки организации
    /// </summary>
    /// <param name="fileContent">Содержимое файла (байты)</param>
    /// <param name="fileName">Имя файла (png, jpg, jpeg или webp, макс. 700 КБ)</param>
    /// <param name="contentType">MIME тип файла</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ с URL загруженной иконки</returns>
    public async Task<InstitutionIconUploadResponse?> UploadIconAsync(
        byte[] fileContent,
        string fileName,
        string contentType,
        CancellationToken cancellationToken = default)
    {
        using var content = new MultipartFormDataContent();
        using var fileStreamContent = new ByteArrayContent(fileContent);
        fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
        content.Add(fileStreamContent, "file", fileName);

        if (!string.IsNullOrEmpty(BearerToken))
        {
            HttpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", BearerToken);
        }

        var response = await HttpClient.PostAsync("/v1/institutions/icon", content, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return System.Text.Json.JsonSerializer.Deserialize<InstitutionIconUploadResponse>(
            responseContent, 
            new System.Text.Json.JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true 
            });
    }
}