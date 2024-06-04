using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Common.Extensions;

public static class MarkExtensions
{
    public static string GetName(this Mark mark)
    {
        switch (mark)
        {
            case Mark.TX:
                return "Технология производства";
            case Mark.AC:
                return "Архитектурно-строительные решения";
            case Mark.CM:
                return "Сметная документация";
            default:
                throw new ArgumentOutOfRangeException(nameof(mark), mark, null);
        }
    }
}
