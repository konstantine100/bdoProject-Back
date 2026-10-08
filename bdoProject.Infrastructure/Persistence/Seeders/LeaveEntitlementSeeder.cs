using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;

namespace bdoProject.Infrastructure.Persistence.Seeders;

public static class LeaveEntitlementSeeder
{
    public static List<LeaveEntitlement> SeededLeaveEntitlements()
{
    return new List<LeaveEntitlement>
    {
        new("E1001", 2026, LEAVE_TYPE.ANNUAL, 25, 3){ Id = 1 },
        new("E1001", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 2 },
        new("E1001", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 3 },
        new("E1001", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 4 },
        new("E1002", 2026, LEAVE_TYPE.ANNUAL, 24, 0){ Id = 5 },
        new("E1002", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 6 },
        new("E1002", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 7 },
        new("E1002", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 8 },
        new("E1003", 2026, LEAVE_TYPE.ANNUAL, 26, 0){ Id = 9 },
        new("E1003", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 10 },
        new("E1003", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 11 },
        new("E1003", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 12 },
        new("E1004", 2026, LEAVE_TYPE.ANNUAL, 8, 0){ Id = 13 },
        new("E1004", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 14 },
        new("E1004", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 15 },
        new("E1004", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 16 },
        new("E1005", 2026, LEAVE_TYPE.ANNUAL, 24, 0){ Id = 17 },
        new("E1005", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 18 },
        new("E1005", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 19 },
        new("E1005", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 20 },
        new("E1006", 2026, LEAVE_TYPE.ANNUAL, 25, 0){ Id = 21 },
        new("E1006", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 22 },
        new("E1006", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 23 },
        new("E1006", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 24 },
        new("E1007", 2026, LEAVE_TYPE.ANNUAL, 25, 0){ Id = 25 },
        new("E1007", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 26 },
        new("E1007", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 27 },
        new("E1007", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 28 },
        new("E1008", 2026, LEAVE_TYPE.ANNUAL, 24, 0){ Id = 29 },
        new("E1008", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 30 },
        new("E1008", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 31 },
        new("E1008", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 32 },
        new("E1009", 2026, LEAVE_TYPE.ANNUAL, 24, 0){ Id = 33 },
        new("E1009", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 34 },
        new("E1009", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 35 },
        new("E1009", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 36 },
        new("E1010", 2026, LEAVE_TYPE.ANNUAL, 26, 0){ Id = 37 },
        new("E1010", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 38 },
        new("E1010", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 39 },
        new("E1010", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 40 },
        new("E1011", 2026, LEAVE_TYPE.ANNUAL, 25, 0){ Id = 41 },
        new("E1011", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 42 },
        new("E1011", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 43 },
        new("E1011", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 44 },
        new("E1012", 2026, LEAVE_TYPE.ANNUAL, 26, 0){ Id = 45 },
        new("E1012", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 46 },
        new("E1012", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 47 },
        new("E1012", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 48 },
        new("E1013", 2026, LEAVE_TYPE.ANNUAL, 25, 0){ Id = 49 },
        new("E1013", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 50 },
        new("E1013", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 51 },
        new("E1013", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 52 },
        new("E1014", 2026, LEAVE_TYPE.ANNUAL, 26, 0){ Id = 53 },
        new("E1014", 2026, LEAVE_TYPE.SICK, 10, 0){ Id = 54 },
        new("E1014", 2026, LEAVE_TYPE.STUDY, 5, 0){ Id = 55 },
        new("E1014", 2026, LEAVE_TYPE.UNPAID, 30, 0){ Id = 56 },
    };
}
}