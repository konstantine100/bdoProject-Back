using bdoProject.Domain.Entities.LeaveAndAbsence;
using bdoProject.Domain.Enums;

namespace bdoProject.Infrastructure.Persistence.Seeders;

public static class LeaveRequestSeeder
{
    public static List<LeaveRequest> SeededLeaveRequests()
{
    return new List<LeaveRequest>
    {
        new("E1001", LEAVE_TYPE.ANNUAL, new(2026, 2, 16), new(2026, 2, 20), 5, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, "პროექტის პარტნიორის თანხმობით"){ Id = 1 },
        new("E1001", LEAVE_TYPE.SICK, new(2026, 3, 10), new(2026, 3, 11), 2, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 2 },
        new("E1001", LEAVE_TYPE.ANNUAL, new(2026, 5, 4), new(2026, 5, 5), 2, LEAVE_REQUEST_STATUS.Cancelled, CREATED_VIA.Portal, "გაუქმებულია თანამშრომლის მიერ"){ Id = 3 },
        new("E1001", LEAVE_TYPE.ANNUAL, new(2026, 7, 13), new(2026, 7, 24), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 4 },
        new("E1001", LEAVE_TYPE.ANNUAL, new(2026, 11, 9), new(2026, 11, 11), 3, LEAVE_REQUEST_STATUS.Pending, CREATED_VIA.Portal, null){ Id = 5 },
        new("E1002", LEAVE_TYPE.ANNUAL, new(2026, 5, 4), new(2026, 5, 8), 5, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 6 },
        new("E1002", LEAVE_TYPE.ANNUAL, new(2026, 8, 3), new(2026, 8, 21), 15, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, "ხელმძღვანელის თანხმობით, 15 სამუშაო დღე"){ Id = 7 },
        new("E1002", LEAVE_TYPE.ANNUAL, new(2026, 10, 26), new(2026, 10, 30), 5, LEAVE_REQUEST_STATUS.Rejected, CREATED_VIA.Portal, "უარყოფილია: კლიენტის პროექტის ვადა"){ Id = 8 },
        new("E1003", LEAVE_TYPE.ANNUAL, new(2026, 4, 6), new(2026, 4, 8), 3, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 9 },
        new("E1003", LEAVE_TYPE.ANNUAL, new(2026, 6, 15), new(2026, 6, 19), 5, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 10 },
        new("E1003", LEAVE_TYPE.ANNUAL, new(2026, 8, 10), new(2026, 8, 12), 3, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 11 },
        new("E1005", LEAVE_TYPE.ANNUAL, new(2026, 3, 23), new(2026, 3, 27), 5, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 12 },
        new("E1005", LEAVE_TYPE.ANNUAL, new(2026, 8, 24), new(2026, 8, 28), 4, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 13 },
        new("E1006", LEAVE_TYPE.ANNUAL, new(2026, 7, 6), new(2026, 7, 17), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 14 },
        new("E1006", LEAVE_TYPE.ANNUAL, new(2026, 11, 16), new(2026, 11, 18), 3, LEAVE_REQUEST_STATUS.Pending, CREATED_VIA.Portal, null){ Id = 15 },
        new("E1007", LEAVE_TYPE.ANNUAL, new(2026, 6, 1), new(2026, 6, 12), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 16 },
        new("E1008", LEAVE_TYPE.ANNUAL, new(2026, 7, 20), new(2026, 7, 31), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 17 },
        new("E1008", LEAVE_TYPE.ANNUAL, new(2026, 9, 14), new(2026, 9, 15), 2, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 18 },
        new("E1009", LEAVE_TYPE.SICK, new(2026, 1, 20), new(2026, 1, 21), 2, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 19 },
        new("E1009", LEAVE_TYPE.ANNUAL, new(2026, 4, 14), new(2026, 4, 17), 4, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 20 },
        new("E1009", LEAVE_TYPE.STUDY, new(2026, 6, 5), new(2026, 6, 5), 1, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, "AZ-900 გამოცდა"){ Id = 21 },
        new("E1009", LEAVE_TYPE.ANNUAL, new(2026, 8, 17), new(2026, 8, 26), 8, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 22 },
        new("E1010", LEAVE_TYPE.ANNUAL, new(2026, 4, 20), new(2026, 4, 30), 9, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 23 },
        new("E1011", LEAVE_TYPE.ANNUAL, new(2026, 8, 10), new(2026, 8, 21), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 24 },
        new("E1012", LEAVE_TYPE.ANNUAL, new(2026, 7, 27), new(2026, 8, 7), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 25 },
        new("E1013", LEAVE_TYPE.ANNUAL, new(2026, 9, 21), new(2026, 9, 25), 5, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 26 },
        new("E1014", LEAVE_TYPE.ANNUAL, new(2026, 6, 22), new(2026, 7, 3), 10, LEAVE_REQUEST_STATUS.Approved, CREATED_VIA.Portal, null){ Id = 27 },
    };
}
}