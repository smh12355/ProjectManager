namespace ProjectManager.Domain.Entities;

public enum Mark
{
    TX,
    AC,
    CM
}

public static class MarkFullName
{
    public static string GetMark(this Mark mark)
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