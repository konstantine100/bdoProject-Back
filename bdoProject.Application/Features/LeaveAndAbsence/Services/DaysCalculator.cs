using bdoProject.Application.Contracts.DaysCalculator;
using bdoProject.Application.Interfaces.Persistence;
using bdoProject.Domain.Entities.Holidays;
using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace bdoProject.Application.Features.LeaveAndAbsence.Services;

public sealed class DaysCalculator : IDaysCalculator
{
    private readonly IDataContext _context;

    public DaysCalculator(IDataContext context) => _context = context;

    public async Task<DaysCalculatorResponse> CalculateDaysWorking(DateOnly startDate, DateOnly endDate)
    {
        List<Holiday> holidays = await _context.Holidays.ToListAsync();

        List<DateOnly> dates = new();

        for (DateOnly date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }
        
        dates = dates.Where(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday).ToList();
        
        List<string> overlappedHolidayNames = holidays
            .Where(x => dates.Contains(x.Date))
            .Select(holiday => holiday.Name)
            .ToList();
        
        int overlappedHolidayCount =  overlappedHolidayNames.Count;

        int overallDays = dates.Count - overlappedHolidayCount;
        string message = $"Overlapped Holidays: {string.Join(", ", overlappedHolidayNames)}";
        
        return new DaysCalculatorResponse(overallDays, message);
    }

    public async Task<DaysCalculatorResponse> CalculateDaysCalendar(DateOnly startDate, DateOnly endDate)
    {
        List<DateOnly> dates = new();

        for (DateOnly date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }

        int overallDays = dates.Count;

        return new DaysCalculatorResponse(overallDays, null);
    }

    public async Task<OverlappingRequestResponse> OverLappingDaysCalculator(
        List<LeaveRequest> requests, DateOnly startDate, DateOnly endDate, int newDays, LEAVE_TYPE leaveType)
    {
        // 1. დამთხვევა: [a,b] და [c,d] იკვეთება, თუ a <= d && b >= c
        if (requests.Any(r => r.StartDate <= endDate && r.EndDate >= startDate))
            return new(true, false, false, null);

        var holidays = (await _context.Holidays.AsNoTracking().Select(h => h.Date).ToListAsync()).ToHashSet();

        bool IsNonWorking(DateOnly d) =>
            d.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday || holidays.Contains(d);

        // დღეები from-სა და to-ს შორის (ორივე გამოკლებით)
        IEnumerable<DateOnly> Between(DateOnly from, DateOnly to) =>
            Enumerable.Range(1, to.DayNumber - from.DayNumber - 1).Select(from.AddDays);

        // რექვესთი "ებმის", თუ შუაში მხოლოდ შაბათ-კვირა/დასვენებაა
        (LeaveRequest Request, int GapDays)? TryLink(LeaveRequest r, DateOnly from, DateOnly to)
        {
            var gap = Between(from, to).ToList();
            return gap.All(IsNonWorking) ? (r, gap.Count) : null;
        }

        // 2. უახლოესი წინა და უახლოესი მომდევნო რექვესთი
        var prev = requests.Where(r => r.EndDate < startDate).MaxBy(r => r.EndDate);
        var next = requests.Where(r => r.StartDate > endDate).MinBy(r => r.StartDate);

        var linked = new[]
            {
                prev is null ? null : TryLink(prev, prev.EndDate, startDate),
                next is null ? null : TryLink(next, endDate, next.StartDate)
            }
            .Where(x => x.HasValue)
            .Select(x => x!.Value)
            .ToList();

        if (linked.Count == 0)
            return new(false, false, false, null);

        // 3. ტიპი: ყველა დაკავშირებული უნდა ემთხვეოდეს ახალის ტიპს
        if (linked.Any(l => l.Request.LeaveType != leaveType))
            return new(false, true, false, null);

        // 4. ჯამი
        var total = newDays
                  + linked.Sum(l => l.Request.Days)
                  + (leaveType == LEAVE_TYPE.UNPAID ? linked.Sum(l => l.GapDays) : 0);

        return new(false, true, true, total);
    }

    public bool BlackOutPeriodMatcher(DateOnly startDate, DateOnly endDate)
    {
        var year = startDate.Year;

        (DateOnly Start, DateOnly End)[] blackouts =
        {
            (new(year, 1, 15), new(year, 3, 15)),
            (new(year, 12, 1), new(year, 12, 20))
        };

        return blackouts.Any(p => p.Start <= endDate && p.End >= startDate);
    }
}