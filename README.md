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

## Иницилизация базы данных
-  В корне репозитория docker-compose -up : docker-hub заблокирован, пока не знаю как подтянуть образ my-sql
-  dotnet ef database update -s ProjectManager --project ProjectManager.Infrastructure/
-  Запуск решения и тестирование api с помощью swagger

## Api
-  Методы рекурсии сделал на скорую руку, их можно оптимизировать(собирался поправить на выходных)
-  Нету фильтрации(собирался добавить на выходных)
