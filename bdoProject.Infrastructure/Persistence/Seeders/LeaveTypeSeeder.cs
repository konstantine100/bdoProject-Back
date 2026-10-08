using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;

namespace bdoProject.Infrastructure.Persistence.Seeders;

public static class LeaveTypeSeeder
{
    public static List<LeaveType> SeededLeaveTypes()
    {
        return new List<LeaveType>
        {
            new(LEAVE_TYPE.ANNUAL, "ყოველწლიური ანაზღაურებადი შვებულება", DAY_UNIT.Working, null, 1, 1, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 4"){ Id = 1 },
            new(LEAVE_TYPE.SICK, "ავადმყოფობის შვებულება", DAY_UNIT.Working, 10, 1, 1, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 6"){ Id = 2 },
            new(LEAVE_TYPE.UNPAID, "უხელფასო შვებულება", DAY_UNIT.Calendar, 30, 1, 1, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 7"){ Id = 3 },
            new(LEAVE_TYPE.BEREAVEMENT, "გლოვის შვებულება", DAY_UNIT.Working, null, 1, 0, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 8"){ Id = 4 },
            new(LEAVE_TYPE.STUDY, "სასწავლო და საგამოცდო შვებულება", DAY_UNIT.Working, 5, 1, 0, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 9"){ Id = 5 },
            new(LEAVE_TYPE.PARENTAL, "მშობლის შვებულება", DAY_UNIT.None, null, 0, 0, "შვებულებისა და გაცდენის პოლიტიკა, მუხლი 10"){ Id = 6 },
        };
    }
}