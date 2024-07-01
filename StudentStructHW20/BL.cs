using System.ComponentModel;
using StudentStructHW20;

namespace _20240522_HW20;

public class BL
{
    const int MaxMark = 100;
    const int MinStudyYear = 2010;
    const int MaxStudyYear = 10;
    const int MinDate = 1950;
    const int MaxDate = 2024;
    const int IdRecordLength = 8;

    public static Group CreateGroup(Supervisor[] supervisorList, string[] idRecords, string initGroupName = null)
    {
        if (initGroupName == null)
        {
            System.Console.Write("Enter groupName: ");
            initGroupName = Console.ReadLine();
        }

        Group initGroup = new Group(
            initGroupName,
            GetDateRandom(MinStudyYear, int.Parse(DateTime.Now.ToString("yyyy"))),
            GetRandomInt(0, MaxStudyYear),
            UI.GetSupervisor(supervisorList),
            null,
            null,
            0,
            GetRandomSpecialization()
        );

        initGroup.GetListOfSubjects();
        initGroup.AddNewStudentsToGroupFromScratch(idRecords);

        return initGroup;
    }

    public static DateTime GetDateRandom(int yearMin = MinDate, int yearMax = MaxDate)
    {
        int year = GetRandomInt(yearMin, yearMax);
        int month = GetRandomInt(1, 12);
        int day = GetRandomInt(1, 28);

        DateTime date = new DateTime(year, month, day);

        return date;
    }

    public static string GetRandomFirstname()
    {
        Random rnd = new Random();

        int value = rnd.Next(1, Enum.GetValues(typeof(FirstNames)).Cast<int>().Max());

        string firstName = Convert.ToString((FirstNames)value);

        return firstName;
    }

    public static string GetRandomLastname()
    {
        Random rnd = new Random();

        int value = rnd.Next(1, Enum.GetValues(typeof(LastNames)).Cast<int>().Max());

        string lastName = Convert.ToString((LastNames)value);

        return lastName;
    }

    public static int GetRandomInt(int minValue = 0, int maxValue = int.MaxValue)
    {
        Random rnd = new Random();

        int value = rnd.Next(minValue, maxValue);

        return value;
    }

    public static int[,] GenerateStudentsMarksWithSubjects(Subject[] subjectsList)
    {
        int[,] marks = new int[subjectsList.Length, 2];

        for (int i = 0; i < marks.GetLength(0); i++)
        {
            marks[i, 0] = (int)subjectsList[i].UseSubjectName;
            marks[i, 1] = GetRandomInt(0, MaxMark);

        }

        return marks;
    }

    public static int[] GenerateMarkOfOneStudentRandom(Subject[] listOfSubjects)
    {
        int[] marks = new int[listOfSubjects.Length];

        for (int i = 0; i < listOfSubjects.Length; i++)
        {
            marks[i] = GetRandomInt(0, MaxMark);
        }

        return marks;
    }

    public static Supervisor[] GetRandomSupervisors(int value = 0)
    {
        if (value == 0)
        {
            value = UI.EnterIntValue("amount of supervisors");
        }

        Supervisor[] supervisorsRandom = new Supervisor[value];

        for (int i = 0; i < supervisorsRandom.Length; i++)
        {
            supervisorsRandom[i].firstName = GetRandomFirstname();
            supervisorsRandom[i].lastName = GetRandomLastname();
            supervisorsRandom[i].supervisorsSpecialization = GetRandomSpecialization();           
        }

        return supervisorsRandom;
    }

    public static Specialization GetRandomSpecialization()
    {
        int value = GetRandomInt(1, Enum.GetValues(typeof(Specialization)).Cast<int>().Max());

        Specialization randomSpecilization = (Specialization)value;

        return randomSpecilization;
    }

    public static Faculty InitArrayOfEmptyGroups(Supervisor[] supervisorList, string[] idRecords,int value = 0)
    {
        if (value == 0)
        {
            value = UI.EnterIntValue("amount of groups");
        }

        Faculty groupList = new Faculty(new Group[value]);

        for (int i = 0; i < groupList.UsefacultyGroups.Length; i++)
        {
            groupList.UsefacultyGroups[i] = CreateGroup(supervisorList, idRecords);
        }

        return groupList;
    }

    public static string GenerateRandomRecordId(string[] idRecords)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        char[] idRecordChar = new char[IdRecordLength];

        for (int i = 0; i < idRecordChar.Length; i++)
        {
            idRecordChar[i] = chars[GetRandomInt(0, chars.Length)];
        }

        string idRecord = new string(idRecordChar);

        if (!CheckUniqueString(idRecords, idRecord))
        {
            string anotherRecord = GenerateRandomRecordId(idRecords);

            return anotherRecord;
        }

        AddRecordToId(ref idRecords, idRecord);

        return idRecord;
    }

    public static bool CheckUniqueString(string[] idRecords, string idRecordToCheck)
    {
        for (int i = 0; i < idRecords.Length; i++)
        {
            if (string.Equals(idRecords[i], idRecordToCheck))
            {
                return false;
            }
        }

        return true;
    }

    public static void AddRecordToId(ref string[] idRecords, string idRecordToAdd)
    {
        Array.Resize(ref idRecords, idRecords.Length + 1);

        idRecords[idRecords.Length - 1] = idRecordToAdd;
    }
}
