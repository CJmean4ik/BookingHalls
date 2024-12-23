namespace Domain.Shared.Static;

public static class TimePeriods
{
    public static readonly TimeOnly StandardStart = new TimeOnly(9, 0);
    public static readonly TimeOnly StandardEnd = new TimeOnly(18, 0);
    public static readonly TimeOnly EveningStart = new TimeOnly(18, 0);
    public static readonly TimeOnly EveningEnd = new TimeOnly(23, 0);
    public static readonly TimeOnly MorningStart = new TimeOnly(6, 0);
    public static readonly TimeOnly MorningEnd = new TimeOnly(9, 0);
    public static readonly TimeOnly PeakStart = new TimeOnly(12, 0);
    public static readonly TimeOnly PeakEnd = new TimeOnly(14, 0);
    
    public static readonly TimeOnly InactiveStart = new TimeOnly(23, 0);
    public static readonly TimeOnly InactiveEnd = new TimeOnly(6, 0); 
}