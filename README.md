# VK Schedule SDK

SDK для работы с API расписания VK Apps. Позволяет программно управлять расписанием занятий и мероприятий образовательных организаций.

<img width="1209" height="263" alt="image" src="https://github.com/user-attachments/assets/940edee1-25f8-447e-81de-3e0944b4f4b7" />


## 📋 Возможности

- ✅ Массовое создание и обновление данных (факультеты, группы, преподаватели, аудитории, события)
- ✅ Управление отдельными событиями расписания (CRUD операции)
- ✅ Загрузка иконки организации
- ✅ Проверка доступности API
- ✅ Полная типизация моделей данных согласно OpenAPI спецификации
- ✅ Поддержка асинхронных операций
- ✅ Документация в формате XML-комментариев

**Требования:**
- .NET 8.0 LTS или новее

## 🔧 Быстрый старт

### Инициализация клиента

```csharp
using VKScheduleSDK.NET.Clients;

// Инициализация с токеном авторизации
var client = new VKScheduleClient("your_bearer_token_here");
```

### Проверка доступности API

```csharp
var healthStatus = await client.HealthCheck.PingAsync();
Console.WriteLine($"API Status: {healthStatus?["status"]}");
```

### Массовое обновление факультетов

```csharp
using VKScheduleSDK.NET.Models.Schemas;

var faculties = new List<FacultySchema>
{
    new()
    {
        FacultyId = "faculty_001",
        FacultyCode = "FAC001",
        FacultyName = "Факультет информатики"
    }
};

var result = await client.Import.UpdateFacultiesAsync(faculties);
Console.WriteLine($"Создано: {result?.CreatedCount}, Обновлено: {result?.UpdatedCount}");
```

### Создание события расписания

```csharp
using VKScheduleSDK.NET.Models.Enums;
using VKScheduleSDK.NET.Models.Schemas;
using VKScheduleSDK.NET.Core; // Для extension methods

var newEvent = new EventSchema
{
    EventId = "event_001",
    EventName = "Лекция по программированию",
    EventDateStart = 1713441232, // Unix timestamp
    EventDateEnd = 1713444832,
    EventType = EventType.Lecture, // Используем английское имя для кода
    GroupId = new List<string> { "group_001" },
    TeacherIds = new List<string> { "teacher_001" },
    RoomIds = new List<string> { "room_001" }
};

// При сериализации EventType автоматически конвертируется в "Лекция" для API
var createdEvent = await client.Events.CreateEventAsync(newEvent);
Console.WriteLine($"Событие создано: {createdEvent?.EventId}");

// Получение русского названия для отображения в UI
var russianName = EventType.Lecture.GetRussianName(); // "Лекция"
Console.WriteLine($"Тип события: {russianName}");
```

### Обновление события

```csharp
var updatedEvent = await client.Events.UpdateEventAsync(newEvent);
```

### Удаление события

```csharp
await client.Events.DeleteEventAsync("event_001");
```

### Загрузка иконки организации

```csharp
var fileBytes = File.ReadAllBytes("icon.png");
var response = await client.Institution.UploadIconAsync(
    fileBytes, 
    "icon.png", 
    "image/png"
);
Console.WriteLine($"Icon URL: {response?.Url}");
```

## 📦 Структура проекта

```
VKScheduleSDK.NET/
├── Clients/
│   ├── VKScheduleClient.cs      # Основной клиент
│   ├── ImportClient.cs          # Массовые операции
│   ├── EventsClient.cs          # Работа с событиями
│   ├── InstitutionClient.cs     # Настройки организации
│   └── HealthCheckClient.cs     # Проверка API
├── Core/
│   ├── ScheduleApiClient.cs     # Базовый класс клиента
│   └── HttpClientExtensions.cs  # Расширения для HTTP
├── Models/
│   ├── Enums/
│   │   ├── EducationForm.cs     # Формы обучения
│   │   ├── EducationLevel.cs    # Уровни обучения
│   │   └── EventType.cs         # Типы событий
│   └── Schemas/
│       ├── BuildingSchema.cs    # Корпуса
│       ├── DepartmentSchema.cs  # Кафедры
│       ├── EventSchema.cs       # События
│       ├── FacultySchema.cs     # Факультеты
│       ├── GroupSchema.cs       # Группы
│       ├── RoomSchema.cs        # Аудитории
│       ├── TeacherSchema.cs     # Преподаватели
│       └── ...                  # Другие схемы
```

## 🔐 Авторизация

API использует Bearer-токен авторизацию. Токен необходимо получить от разработчиков VK Schedule.

```csharp
// Все запросы автоматически добавляют заголовок Authorization
var client = new VKScheduleClient("your_bearer_token");
```

## 📚 Документация

- [Swagger API](https://schedule.vk-apps.com/docs#/)

## 🤝 Вклад в проект

1. Fork репозитория
2. Создайте ветку для вашей фичи (`git checkout -b feature/amazing-feature`)
3. Закоммитьте изменения (`git commit -m 'Add amazing feature'`)
4. Push в ветку (`git push origin feature/amazing-feature`)
5. Откройте Pull Request

## 📄 Лицензия

Распространяется под лицензией MIT. Подробнее см. файл [LICENSE](LICENSE).

---

> **Внимание**: Проект не является официальным и не имеет никакого отношения к команде VK или к разработчикам VK Schedule
