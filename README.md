# ProjectManager

## Архитектура
Придерживался [CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture)

## Api
-  Получение дерева проектов и дизайн обьектов слева:
  -  Первый способ: /api/Project - получение отдельно проектов, /api/Project/{projectId}/DesignObject - получение дизайн обьектов по Id проекта.
  -  Второй способ: /api/Project/IncludeDesignObjects - проекты с дизайнобьектами в древовидной структуре.
-  Получение по проекту таблицы справа: /api/Project/DesignObject/DosSet/ByProject
-  Получение по дизайну обьекта таблицы справа: /api/Project/DesignObject/DosSet/ByDesignObject

## Иницилизация базы данных
-  В корне репозитория docker-compose -up : docker-hub заблокирован, пока не знаю как подтянуть образ my-sql
-  dotnet ef database update -s ProjectManager --project ProjectManager.Infrastructure/
-  Запуск решения и тестирование api с помощью swagger

## Api
-  Методы рекурсии сделал на скорую руку, их можно оптимизировать(собирался поправить на выходных)
-  Нету фильтрации(собирался добавить на выходных)
