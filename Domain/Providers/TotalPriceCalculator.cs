using Domain.Models;
using Domain.Shared.Static;

namespace Domain.Providers;

public class TotalPriceCalculator
{
    public static decimal CalculatePrice(List<Service> services, TimeOnly startEvent, decimal baseHallPrice, int duration)
    {
        decimal totalPrice = (baseHallPrice * duration) + services.Sum(s => s.Price);
        decimal tempPrice = 0;
        
        if (IsWithinPeriod(startEvent,TimePeriods.MorningStart,TimePeriods.MorningEnd))
        {
            tempPrice = totalPrice / 10;
            totalPrice -= tempPrice;
        }         
        if (IsWithinPeriod(startEvent,TimePeriods.PeakStart,TimePeriods.PeakEnd))
        {
            tempPrice = totalPrice / 15;
            totalPrice += tempPrice;
        } 
        if (IsWithinPeriod(startEvent,TimePeriods.EveningStart,TimePeriods.EveningEnd))
        {
            tempPrice = totalPrice / 20;
            totalPrice -= tempPrice;
        }

        return totalPrice;
    }
    
    private static bool IsWithinPeriod(TimeOnly time, TimeOnly periodStart, TimeOnly periodEnd)
    {
        return time >= periodStart && time <= periodEnd;
    }
}