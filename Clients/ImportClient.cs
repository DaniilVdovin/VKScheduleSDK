using VKScheduleSDK.NET.Core;
using VKScheduleSDK.NET.Models.Schemas;

namespace VKScheduleSDK.NET.Clients;

/// <summary>
/// Клиент для методов импорта (массовое создание/обновление данных)
/// </summary>
public class ImportClient : ScheduleApiClient
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ImportClient"/>
    /// </summary>
    /// <param name="bearerToken">Bearer токен для авторизации</param>
    /// <param name="baseUrl">Базовый URL API</param>
    public ImportClient(string bearerToken, string? baseUrl = null) 
        : base(bearerToken, baseUrl)
    {
    }

    /// <summary>
    /// Добавление или обновление факультетов
    /// </summary>
    /// <param name="faculties">Список факультетов</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateFacultiesAsync(
        IEnumerable<FacultySchema> faculties,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<FacultySchema, BulkOpsResponseSchema>(
            "/v1/bulk/faculties",
            faculties,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление академических групп
    /// </summary>
    /// <param name="groups">Список групп</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateGroupsAsync(
        IEnumerable<GroupSchema> groups,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<GroupSchema, BulkOpsResponseSchema>(
            "/v1/bulk/groups",
            groups,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление подгрупп
    /// </summary>
    /// <param name="subGroups">Список подгрупп</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateSubGroupsAsync(
        IEnumerable<SubGroupSchema> subGroups,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<SubGroupSchema, BulkOpsResponseSchema>(
            "/v1/bulk/sub_groups",
            subGroups,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление корпусов
    /// </summary>
    /// <param name="buildings">Список корпусов</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateBuildingsAsync(
        IEnumerable<BuildingSchema> buildings,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<BuildingSchema, BulkOpsResponseSchema>(
            "/v1/bulk/buildings",
            buildings,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление аудиторий
    /// </summary>
    /// <param name="rooms">Список аудиторий</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateRoomsAsync(
        IEnumerable<RoomSchema> rooms,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<RoomSchema, BulkOpsResponseSchema>(
            "/v1/bulk/rooms",
            rooms,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление преподавателей
    /// </summary>
    /// <param name="teachers">Список преподавателей</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateTeachersAsync(
        IEnumerable<TeacherSchema> teachers,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<TeacherSchema, BulkOpsResponseSchema>(
            "/v1/bulk/teachers",
            teachers,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление кафедр
    /// </summary>
    /// <param name="departments">Список кафедр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateDepartmentsAsync(
        IEnumerable<DepartmentSchema> departments,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<DepartmentSchema, BulkOpsResponseSchema>(
            "/v1/bulk/departments",
            departments,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление событий расписания (для всех групп)
    /// </summary>
    /// <param name="events">Список событий</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateEventsAsync(
        IEnumerable<EventSchema> events,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<EventSchema, BulkOpsResponseSchema>(
            "/v1/bulk/events",
            events,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление событий расписания по конкретной группе
    /// </summary>
    /// <param name="groupId">ID группы</param>
    /// <param name="events">Список событий</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateGroupEventsAsync(
        string groupId,
        IEnumerable<EventSchema> events,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<EventSchema, BulkOpsResponseSchema>(
            $"/v1/bulk/events/{groupId}",
            events,
            BearerToken,
            cancellationToken);
    }

    /// <summary>
    /// Добавление или обновление типов событий расписания
    /// </summary>
    /// <param name="eventTypes">Список типов событий</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    public async Task<BulkOpsResponseSchema?> UpdateEventTypesAsync(
        IEnumerable<EventTypeInSchema> eventTypes,
        CancellationToken cancellationToken = default)
    {
        return await HttpClient.PostJsonArrayAsync<EventTypeInSchema, BulkOpsResponseSchema>(
            "/v1/bulk/event_types",
            eventTypes,
            BearerToken,
            cancellationToken);
    }
}