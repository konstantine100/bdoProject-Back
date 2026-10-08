using bdoProject.Domain.Entities.Employees;
using bdoProject.Domain.Enums;

namespace bdoProject.Infrastructure.Persistence.Seeders;

public static class EmployeeSeeder
{
    public static List<Employee> SeededEmployees()
{
    return new List<Employee>
    {
        new("E1001", "ნინო ბერიძე", "nino.beridze@northstar.example", DEPARTMENT_CODE.AUD, "აუდიტი და მარწმუნებელი მომსახურება", "უფროსი აუდიტორი", EMPLOYMENT_TYPE.FULL_TIME, new(2019, 3, 4), new(2019, 6, 3), "E1010", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR) { Id = 1 },
        new("E1002", "ალექსანდრე კაპანაძე", "aleksandre.kapanadze@northstar.example", DEPARTMENT_CODE.ADV, "საკონსულტაციო მომსახურება", "კონსულტანტი", EMPLOYMENT_TYPE.FULL_TIME, new(2024, 6, 10), new(2024, 9, 9), "E1011", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 2 },
        new("E1003", "ქეთევან ლომიძე", "ketevan.lomidze@northstar.example", DEPARTMENT_CODE.TAX, "საგადასახადო მომსახურება", "საგადასახადო მენეჯერი", EMPLOYMENT_TYPE.FULL_TIME, new(2014, 9, 15), new(2014, 12, 14), "E1012", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 3 },
        new("E1004", "ლუკა წიკლაური", "luka.tsiklauri@northstar.example", DEPARTMENT_CODE.TEC, "ტექნოლოგიები და ავტომატიზაცია", "ავტომატიზაციის უმცროსი დეველოპერი", EMPLOYMENT_TYPE.FULL_TIME, new(2026, 9, 1), new(2026, 11, 30), "E1013", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 4 },
        new("E1005", "ანა გელაშვილი", "ana.gelashvili@northstar.example", DEPARTMENT_CODE.AUD, "აუდიტი და მარწმუნებელი მომსახურება", "აუდიტის ასოცირებული სპეციალისტი", EMPLOYMENT_TYPE.FULL_TIME, new(2023, 2, 1), new(2023, 4, 30), "E1010", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 5 },
        new("E1006", "დავით მაისურაძე", "davit.maisuradze@northstar.example", DEPARTMENT_CODE.ADV, "საკონსულტაციო მომსახურება", "უფროსი კონსულტანტი", EMPLOYMENT_TYPE.FULL_TIME, new(2021, 5, 17), new(2021, 8, 16), "E1011", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 6 },
        new("E1007", "თამარ ჯორჯაძე", "tamar.jorjadze@northstar.example", DEPARTMENT_CODE.HRS, "ადამიანური რესურსების სამსახური", "HR ბიზნეს პარტნიორი", EMPLOYMENT_TYPE.FULL_TIME, new(2020, 1, 13), new(2020, 4, 12), "E1014", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.HR){ Id = 7 },
        new("E1008", "ლევან აბაშიძე", "levan.abashidze@northstar.example", DEPARTMENT_CODE.FIN, "ფინანსები და ადმინისტრირება", "ბუღალტერი", EMPLOYMENT_TYPE.FULL_TIME, new(2022, 8, 1), new(2022, 10, 31), "E1014", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 8 },
        new("E1009", "სალომე ხუციშვილი", "salome.khutsishvili@northstar.example", DEPARTMENT_CODE.TEC, "ტექნოლოგიები და ავტომატიზაცია", "ავტომატიზაციის კონსულტანტი", EMPLOYMENT_TYPE.FULL_TIME, new(2022, 1, 10), new(2022, 4, 9), "E1013", EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 9 },
        new("E1010", "ირაკლი ნოზაძე", "irakli.nozadze@northstar.example", DEPARTMENT_CODE.AUD, "აუდიტი და მარწმუნებელი მომსახურება", "აუდიტის მენეჯერი", EMPLOYMENT_TYPE.FULL_TIME, new(2015, 4, 1), new(2015, 6, 30), null, EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 10 },
        new("E1011", "ეკა ჩხეიძე", "eka.chkheidze@northstar.example", DEPARTMENT_CODE.ADV, "საკონსულტაციო მომსახურება", "საკონსულტაციო მენეჯერი", EMPLOYMENT_TYPE.FULL_TIME, new(2017, 10, 2), new(2018, 1, 1), null, EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 11 },
        new("E1012", "ბექა ქავთარაძე", "beka.kavtaradze@northstar.example", DEPARTMENT_CODE.TAX, "საგადასახადო მომსახურება", "საგადასახადო დირექტორი", EMPLOYMENT_TYPE.FULL_TIME, new(2013, 3, 18), new(2013, 6, 17), null, EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 12 },
        new("E1013", "თეონა გოგოლაძე", "teona.gogoladze@northstar.example", DEPARTMENT_CODE.TEC, "ტექნოლოგიები და ავტომატიზაცია", "ავტომატიზაციის მენეჯერი", EMPLOYMENT_TYPE.FULL_TIME, new(2018, 2, 19), new(2018, 5, 18), null, EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 13 },
        new("E1014", "ნიკა შენგელია", "nika.shengelia@northstar.example", DEPARTMENT_CODE.FIN, "ფინანსები და ადმინისტრირება", "ფინანსური დირექტორი", EMPLOYMENT_TYPE.FULL_TIME, new(2016, 6, 6), new(2016, 9, 5), null, EMPLOYMENT_STATUS.ACTIVE, EMPLOYEE_ROLE.Non_HR){ Id = 14 },
    };
}
}