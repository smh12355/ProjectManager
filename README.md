# ProjectManager

## Архитектура
Придерживался [CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture)

## Api
-  Получение дерева проектов и дизайн обьектов слева:
  -  Первый способ: /api/Project - получение отдельно проектов, /api/Project/{projectId}/DesignObject - получение дизайн обьектов по Id проекта.
  -  Второй способ: /api/Project/IncludeDesignObjects - проекты с дизайнобьектами в древовидной структуре.
