
# ProjectManager

## Архитектура
Проект следует принципам [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture).

## API

### Получение дерева проектов и дизайн объектов
1. Первый способ:
   - `/api/Project` - получение списка проектов.
   - `/api/Project/{projectId}/DesignObject` - получение дизайн объектов по ID проекта.
2. Второй способ:
   - `/api/Project/IncludeDesignObjects` - получение проектов с дизайн объектами в древовидной структуре.

### Получение данных таблицы справа
- По проекту: `/api/Project/DesignObject/DosSet/ByProject/{ProjectId}`
- По дизайн объекту: `/api/Project/DesignObject/DosSet/ByDesignObject/{DesignObjectId}`

## Инициализация базы данных
1. В каталоге `ProjectManager` репозитория выполните команду:
   ```sh
   docker-compose up
   ```
2. Примените миграции в корне репозитория:
   ```sh
   dotnet ef database update -s ProjectManager --project ProjectManager.Infrastructure/
   ```
3. Запустите решение и протестируйте API с помощью Swagger.

## Примечания
- Методы рекурсии были сделаны на скорую руку и могут быть оптимизированы. Планирую исправить это на выходных.
- Фильтрация пока не добавлена, но она также будет добавлена на выходных.
