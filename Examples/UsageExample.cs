using VKScheduleSDK.NET.Clients;
using VKScheduleSDK.NET.Core;
using VKScheduleSDK.NET.Models.Enums;
using VKScheduleSDK.NET.Models.Schemas;

namespace VKScheduleSDK.NET.Examples;

/// <summary>
/// Примеры использования VK Schedule SDK
/// </summary>
public static class UsageExample
{
    /// <summary>
    /// Пример полной инициализации и использования клиента
    /// </summary>
    public static async Task RunExampleAsync()
    {
        // Инициализация клиента с токеном
        var client = new VKScheduleClient("your_bearer_token_here");

        try
        {
            // 1. Проверка доступности API
            var healthStatus = await client.HealthCheck.PingAsync();
            Console.WriteLine($"API доступен: {healthStatus != null}");

            // 2. Подготовка данных для массового обновления
            var faculties = new List<FacultySchema>
            {
                new()
                {
                    FacultyId = "fac_001",
                    FacultyCode = "IT",
                    FacultyName = "Факультет информационных технологий"
                }
            };

            var groups = new List<GroupSchema>
            {
                new()
                {
                    GroupId = "grp_001",
                    GroupCode = "БИ-2024-1",
                    GroupName = "Бизнес-информатика, группа 1",
                    FacultyId = "fac_001",
                    CourseNumber = 1,
                    EducationForm = EducationForm.FULLTIME,
                    EducationLevel = EducationLevel.BACHELOR
                }
            };

            var teachers = new List<TeacherSchema>
            {
                new()
                {
                    TeacherId = "tch_001",
                    TeacherName = "Иванов И.И.",
                    TeacherFullName = "Иванов Иван Иванович",
                    TeacherRank = "Доцент"
                }
            };

            // 3. Массовое обновление данных
            var facultyResult = await client.Import.UpdateFacultiesAsync(faculties);
            Console.WriteLine($"Факультеты: создано={facultyResult?.CreatedCount}, обновлено={facultyResult?.UpdatedCount}");

            var groupResult = await client.Import.UpdateGroupsAsync(groups);
            Console.WriteLine($"Группы: создано={groupResult?.CreatedCount}, обновлено={groupResult?.UpdatedCount}");

            var teacherResult = await client.Import.UpdateTeachersAsync(teachers);
            Console.WriteLine($"Преподаватели: создано={teacherResult?.CreatedCount}, обновлено={teacherResult?.UpdatedCount}");

            // 4. Создание события расписания
            var newEvent = new EventSchema
            {
                EventId = "evt_001",
                EventName = "Введение в программирование",
                EventDateStart = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                EventDateEnd = DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds(),
                EventType = EventType.Lecture,
                GroupId = new List<string> { "grp_001" },
                TeacherIds = new List<string> { "tch_001" }
            };

            var createdEvent = await client.Events.CreateEventAsync(newEvent);
            Console.WriteLine($"Событие создано: {createdEvent?.EventId}");

            // 5. Обновление события
            newEvent.EventName = "Введение в программирование (обновлено)";
            var updatedEvent = await client.Events.UpdateEventAsync(newEvent);
            Console.WriteLine($"Событие обновлено: {updatedEvent?.EventName}");

            // 6. Удаление события
            await client.Events.DeleteEventAsync("evt_001");
            Console.WriteLine("Событие удалено");
        }
        finally
        {
            // Освобождение ресурсов
            client.Dispose();
        }
    }

    /// <summary>
    /// Пример работы с расширениями для EventType
    /// </summary>
    public static void EventTypeExtensionsExample()
    {
        // Получение русского названия из английского значения enum
        var eventType = EventType.Lecture;
        var russianName = eventType.GetRussianName(); // "Лекция"
        Console.WriteLine($"Русское название: {russianName}");

        // Обратное преобразование: из русского названия в enum
        var parsedType = EnumExtensions.FromRussianName("Практическое занятие");
        if (parsedType.HasValue)
        {
            Console.WriteLine($"Найдено значение: {parsedType.Value}");
        }

        // Получение всех русских названий
        var allTypes = EnumExtensions.GetAllRussianEventTypes();
        Console.WriteLine($"Доступные типы событий: {string.Join(", ", allTypes)}");

        // Получение описаний для других enum
        Console.WriteLine($"FULLTIME = {EducationForm.FULLTIME.GetDescription()}"); // "Очная"
        Console.WriteLine($"BACHELOR = {EducationLevel.BACHELOR.GetDescription()}"); // "Бакалавриат"
    }

    /// <summary>
    /// Пример загрузки иконки организации
    /// </summary>
    public static async Task UploadIconExampleAsync(VKScheduleClient client)
    {
        // Чтение файла иконки
        var iconPath = "path/to/icon.png";
        var fileBytes = await File.ReadAllBytesAsync(iconPath);
        
        // Загрузка иконки
        var response = await client.Institution.UploadIconAsync(
            fileBytes,
            Path.GetFileName(iconPath),
            "image/png"
        );
        
        Console.WriteLine($"Иконка загружена: {response?.Url}");
    }

    /// <summary>
    /// Пример обработки ошибок
    /// </summary>
    public static async Task ErrorHandlingExampleAsync()
    {
        var client = new VKScheduleClient("invalid_token");

        try
        {
            await client.HealthCheck.PingAsync();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP ошибка: {ex.Message}");
            // Обработка ошибок сети
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Запрос отменен или истек таймаут");
            // Обработка таймаутов
        }
        finally
        {
            client.Dispose();
        }
    }
}